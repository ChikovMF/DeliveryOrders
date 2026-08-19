import { useState, useEffect } from 'react'
import OrderForm from './components/OrderForm'
import OrderList from './components/OrderList'
import OrderDetails from './components/OrderDetails'

function App() {
  const [orders, setOrders] = useState([])
  const [selectedOrder, setSelectedOrder] = useState(null)
  const [loading, setLoading] = useState(false)

  const fetchOrders = async () => {
    try {
      const response = await fetch('/api/orders')
      if (response.ok) {
        const data = await response.json()
        setOrders(data.orders || [])
      }
    } catch (error) {
      console.error('Ошибка загрузки заказов:', error)
    }
  }

  useEffect(() => {
    fetchOrders()
  }, [])

  const handleOrderCreated = () => {
    fetchOrders()
  }

  const handleOrderClick = async (orderNumber) => {
    setLoading(true)
    try {
      const response = await fetch(`/api/orders/${orderNumber}`)
      if (response.ok) {
        const data = await response.json()
        setSelectedOrder(data)
      }
    } catch (error) {
      console.error('Ошибка загрузки заказа:', error)
    } finally {
      setLoading(false)
    }
  }

  const handleCloseDetails = () => {
    setSelectedOrder(null)
  }

  return (
    <div className="app">
      <h1>Система управления заказами</h1>
      <div className="container">
        <OrderForm onOrderCreated={handleOrderCreated} />
        <OrderList orders={orders} onOrderClick={handleOrderClick} />
      </div>
      {selectedOrder && (
        <OrderDetails order={selectedOrder} onClose={handleCloseDetails} />
      )}
    </div>
  )
}

export default App

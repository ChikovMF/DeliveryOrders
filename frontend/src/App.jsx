import { useState, useEffect } from 'react'
import OrderForm from './components/OrderForm'
import OrderList from './components/OrderList'
import OrderDetails from './components/OrderDetails'

function App() {
  const [orders, setOrders] = useState([])
  const [selectedOrder, setSelectedOrder] = useState(null)
  const [loading, setLoading] = useState(false)
  const [currentPage, setCurrentPage] = useState(0)
  const [pageSize, setPageSize] = useState(10)
  const [totalOrders, setTotalOrders] = useState(0)

  const fetchOrders = async (offset = 0) => {
    try {
      const response = await fetch(`/api/orders?offset=${offset}&limit=${pageSize}`)
      if (response.ok) {
        const data = await response.json()
        setOrders(data.orders || [])
        setTotalOrders(data.orders?.length || 0)
      }
    } catch (error) {
      console.error('Ошибка загрузки заказов:', error)
    }
  }

  useEffect(() => {
    fetchOrders(currentPage * pageSize)
  }, [currentPage, pageSize])

  const handleOrderCreated = () => {
    setCurrentPage(0)
    fetchOrders(0)
  }

  const handleNextPage = () => {
    if (totalOrders === pageSize) {
      setCurrentPage(prev => prev + 1)
    }
  }

  const handlePrevPage = () => {
    if (currentPage > 0) {
      setCurrentPage(prev => prev - 1)
    }
  }

  const handlePageSizeChange = (newSize) => {
    setPageSize(newSize)
    setCurrentPage(0)
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
        <OrderList 
          orders={orders} 
          onOrderClick={handleOrderClick}
          currentPage={currentPage}
          pageSize={pageSize}
          hasMore={totalOrders === pageSize}
          onNextPage={handleNextPage}
          onPrevPage={handlePrevPage}
          onPageSizeChange={handlePageSizeChange}
        />
      </div>
      {selectedOrder && (
        <OrderDetails order={selectedOrder} onClose={handleCloseDetails} />
      )}
    </div>
  )
}

export default App

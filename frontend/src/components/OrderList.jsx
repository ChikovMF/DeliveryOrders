function OrderList({ orders, onOrderClick }) {
  const formatDate = (dateString) => {
    const date = new Date(dateString)
    return date.toLocaleString('ru-RU', {
      year: 'numeric',
      month: '2-digit',
      day: '2-digit',
      hour: '2-digit',
      minute: '2-digit'
    })
  }

  return (
    <div className="card">
      <h2>Список заказов</h2>
      {orders.length === 0 ? (
        <div className="empty-state">Заказов пока нет</div>
      ) : (
        <ul className="orders-list">
          {orders.map((order) => (
            <li
              key={order.number}
              className="order-item"
              onClick={() => onOrderClick(order.number)}
            >
              <div className="order-number">Заказ: {order.number}</div>
              <div className="order-info">
                {order.senderCity} → {order.recipientCity}
              </div>
              <div className="order-info">
                Вес: {order.weight} кг
              </div>
              <div className="order-info">
                Дата забора: {formatDate(order.pickupDate)}
              </div>
            </li>
          ))}
        </ul>
      )}
    </div>
  )
}

export default OrderList

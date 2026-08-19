function OrderDetails({ order, onClose }) {
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
    <div className="modal" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <div className="modal-header">
          <h2>Заказ: {order.number}</h2>
          <button className="close-button" onClick={onClose}>
            ×
          </button>
        </div>

        <div className="order-detail">
          <div className="order-detail-label">Номер заказа</div>
          <div className="order-detail-value">{order.number}</div>
        </div>

        <div className="order-detail">
          <div className="order-detail-label">Город отправителя</div>
          <div className="order-detail-value">{order.senderCity}</div>
        </div>

        <div className="order-detail">
          <div className="order-detail-label">Адрес отправителя</div>
          <div className="order-detail-value">{order.senderAddress}</div>
        </div>

        <div className="order-detail">
          <div className="order-detail-label">Город получателя</div>
          <div className="order-detail-value">{order.recipientCity}</div>
        </div>

        <div className="order-detail">
          <div className="order-detail-label">Адрес получателя</div>
          <div className="order-detail-value">{order.recipientAddress}</div>
        </div>

        <div className="order-detail">
          <div className="order-detail-label">Вес груза</div>
          <div className="order-detail-value">{order.weight} кг</div>
        </div>

        <div className="order-detail">
          <div className="order-detail-label">Дата забора груза</div>
          <div className="order-detail-value">{formatDate(order.pickupDate)}</div>
        </div>
      </div>
    </div>
  )
}

export default OrderDetails

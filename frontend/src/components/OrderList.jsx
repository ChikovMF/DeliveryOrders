function OrderList({ orders, onOrderClick, currentPage, pageSize, hasMore, onNextPage, onPrevPage, onPageSizeChange }) {
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
        <>
          <ul className="orders-list">
            {orders.map((order) => (
              <li
                key={order.number}
                className="order-item"
                onClick={() => onOrderClick(order.number)}
              >
                <div className="order-number">Заказ {order.number}</div>
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
          
          <div className="pagination">
            <div className="pagination-controls">
              {currentPage > 0 && (
                <button 
                  onClick={onPrevPage}
                  className="pagination-button"
                >
                  ← Назад
                </button>
              )}
              <span className="page-info">
                Страница {currentPage + 1}
              </span>
              {hasMore && (
                <button 
                  onClick={onNextPage}
                  className="pagination-button"
                >
                  Вперед →
                </button>
              )}
            </div>
            <div className="page-size-selector">
              <label htmlFor="pageSize">На странице:</label>
              <select 
                id="pageSize"
                value={pageSize} 
                onChange={(e) => onPageSizeChange(Number(e.target.value))}
                className="page-size-select"
              >
                <option value={5}>5</option>
                <option value={10}>10</option>
                <option value={20}>20</option>
                <option value={50}>50</option>
              </select>
            </div>
          </div>
        </>
      )}
    </div>
  )
}

export default OrderList

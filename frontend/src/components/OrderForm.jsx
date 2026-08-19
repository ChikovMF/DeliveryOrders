import { useState } from 'react'

function OrderForm({ onOrderCreated }) {
  const [formData, setFormData] = useState({
    senderCity: '',
    senderAddress: '',
    recipientCity: '',
    recipientAddress: '',
    weight: '',
    pickupDate: ''
  })
  const [error, setError] = useState('')
  const [success, setSuccess] = useState('')
  const [loading, setLoading] = useState(false)

  const handleChange = (e) => {
    const { name, value } = e.target
    setFormData(prev => ({
      ...prev,
      [name]: value
    }))
    setError('')
    setSuccess('')
  }

  const handleSubmit = async (e) => {
    e.preventDefault()
    setError('')
    setSuccess('')

    if (!formData.senderCity || !formData.senderAddress || 
        !formData.recipientCity || !formData.recipientAddress || 
        !formData.weight || !formData.pickupDate) {
      setError('Все поля обязательны для заполнения')
      return
    }

    setLoading(true)

    try {
      const response = await fetch('/api/orders', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          senderCity: formData.senderCity,
          senderAddress: formData.senderAddress,
          recipientCity: formData.recipientCity,
          recipientAddress: formData.recipientAddress,
          weight: parseFloat(formData.weight),
          pickupDate: new Date(formData.pickupDate).toISOString()
        })
      })

      if (response.ok) {
        const data = await response.json()
        setSuccess(`Заказ успешно создан! Номер: ${data.number}`)
        setFormData({
          senderCity: '',
          senderAddress: '',
          recipientCity: '',
          recipientAddress: '',
          weight: '',
          pickupDate: ''
        })
        onOrderCreated()
      } else {
        const errorText = await response.text()
        setError(errorText || 'Ошибка создания заказа')
      }
    } catch (err) {
      setError('Ошибка соединения с сервером')
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="card">
      <h2>Создание нового заказа</h2>
      {error && <div className="error">{error}</div>}
      {success && <div className="success">{success}</div>}
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="senderCity">Город отправителя *</label>
          <input
            type="text"
            id="senderCity"
            name="senderCity"
            value={formData.senderCity}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="senderAddress">Адрес отправителя *</label>
          <input
            type="text"
            id="senderAddress"
            name="senderAddress"
            value={formData.senderAddress}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="recipientCity">Город получателя *</label>
          <input
            type="text"
            id="recipientCity"
            name="recipientCity"
            value={formData.recipientCity}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="recipientAddress">Адрес получателя *</label>
          <input
            type="text"
            id="recipientAddress"
            name="recipientAddress"
            value={formData.recipientAddress}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="weight">Вес груза (кг) *</label>
          <input
            type="number"
            id="weight"
            name="weight"
            step="0.01"
            min="0"
            value={formData.weight}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="pickupDate">Дата забора груза *</label>
          <input
            type="datetime-local"
            id="pickupDate"
            name="pickupDate"
            value={formData.pickupDate}
            onChange={handleChange}
            required
          />
        </div>

        <button type="submit" disabled={loading}>
          {loading ? 'Создание...' : 'Создать заказ'}
        </button>
      </form>
    </div>
  )
}

export default OrderForm

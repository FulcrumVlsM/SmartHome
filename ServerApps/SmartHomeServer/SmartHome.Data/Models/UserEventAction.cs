namespace SmartHome.Data.Models
{
    /// <summary>
    /// Действие над пользователем при событии от устройства
    /// </summary>
    public class UserEventAction
    {
        public int ID { get; set; }
        
        public int EventDeviceID { get; set; }

        public EventDevice EventDevice { get; set; }


        /// <summary>
        /// Устанавливаемое значение (true - в доме, false - вне дома)
        /// </summary>
        public bool AssignedValue { get; set; }
    }
}

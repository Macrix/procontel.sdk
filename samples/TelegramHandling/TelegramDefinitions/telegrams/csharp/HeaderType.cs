//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelegramDefinitions.Telegrams {
    
    
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable()]
    public partial class HeaderType {
        
        private System.Int16? _messageLength;
        
        private System.Int16? _messageId;
        
        private System.Int16? _messageCount;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderType"/> class.
        /// </summary>
        public HeaderType() : 
                this(true) {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderType"/> class.
        /// </summary>
        /// <param name="initWithDefaultValues">Determines whether the telegram should be initialized with default values.</param>
        public HeaderType(bool initWithDefaultValues) {
            if (initWithDefaultValues) {
                MessageLength = 0;
                MessageId = 0;
                MessageCount = 0;
            }
        }
        
        /// <summary>
        /// Gets or sets the header plus data.
        /// </summary>
        /// <value>The MessageLength.</value>
        [System.Xml.Serialization.XmlElement("MessageLength", IsNullable=true)]
        public System.Int16? MessageLength {
            get {
                return this._messageLength;
            }
            set {
                this._messageLength = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the Message Id.
        /// </summary>
        /// <value>The MessageId.</value>
        [System.Xml.Serialization.XmlElement("MessageId", IsNullable=true)]
        public System.Int16? MessageId {
            get {
                return this._messageId;
            }
            set {
                this._messageId = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the Message counter 
        ///[0..65535] - wrap around.
        /// </summary>
        /// <value>The MessageCount.</value>
        [System.Xml.Serialization.XmlElement("MessageCount", IsNullable=true)]
        public System.Int16? MessageCount {
            get {
                return this._messageCount;
            }
            set {
                this._messageCount = value;
            }
        }
    }
}

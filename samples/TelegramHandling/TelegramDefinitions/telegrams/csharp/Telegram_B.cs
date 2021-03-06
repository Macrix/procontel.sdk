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
    [System.Xml.Serialization.XmlRoot("Telegram")]
    [System.Serializable()]
    public partial class Telegram_B {
        
        private static string _headerXsbtDefinition = "<?xml version='1.0' encoding='utf-16'?><Telegram name='HeaderType' ID='' bytes='6' IsHeaderType='True' ContainsHeaderType='True'><element name='MessageLength' type='Short' length='2' offset='0' HeaderHint='Length' comment='header plus data' /><element name='MessageId' type='Short' length='2' offset='2' HeaderHint='ID' comment='Message Id' /><element name='MessageCount' type='Short' length='2' offset='4' HeaderHint='MessageCounter' comment='Message counter &#xA;[0..65535] - wrap around' /></Telegram>";
        
        private static string _telegramXsbtDefinition = "<?xml version='1.0' encoding='utf-16'?><Telegram name='Telegram_B' ID='44' bytes='66' ContainsHeaderType='True'><element name='HEAD' type='HeaderType' length='6' offset='0' count='1' comment='Header'><element name='MessageLength' type='Short' length='2' offset='0' count='1' comment='header plus data' /><element name='MessageId' type='Short' length='2' offset='2' count='1' comment='Message Id' /><element name='MessageCount' type='Short' length='2' offset='4' count='1' comment='Message counter &#xA;[0..65535] - wrap around' /></element><element name='Int_1Byte' type='unsignedByte' length='1' offset='6' count='2' comment='[#]' /><element name='Int_2Byte' type='Short' length='2' offset='8' count='2' comment='[#]' /><element name='Int_4Byte' type='int' length='4' offset='12' count='2' comment='[#]' /><element name='Int_8Byte' type='long' length='8' offset='20' count='2' comment='[#]' /><element name='Integer_1Byte' type='unsignedByte' length='1' offset='36' count='2' comment='[#]' /><element name='Integer_2Byte' type='Short' length='2' offset='38' count='2' comment='[#]' /><element name='Integer_4Byte' type='int' length='4' offset='42' count='2' comment='[#]' /><element name='Integer_8Byte' type='long' length='8' offset='50' count='2' comment='[#]' /></Telegram>";
        
        private HeaderType _hEAD = new HeaderType();
        
        private System.Byte?[] _int_1Byte = new System.Byte?[2];
        
        private System.Int16?[] _int_2Byte = new System.Int16?[2];
        
        private System.Int32?[] _int_4Byte = new System.Int32?[2];
        
        private System.Int64?[] _int_8Byte = new System.Int64?[2];
        
        private System.Byte?[] _integer_1Byte = new System.Byte?[2];
        
        private System.Int16?[] _integer_2Byte = new System.Int16?[2];
        
        private System.Int32?[] _integer_4Byte = new System.Int32?[2];
        
        private System.Int64?[] _integer_8Byte = new System.Int64?[2];
        
        private static string _name = "Telegram_B";
        
        private static string _iD = "44";
        
        /// <summary>
        /// Defines the fullname of telegram including namespace.
        /// </summary>
        public const string TelegramFullname = "TelegramDefinitions.Telegrams.Telegram_B";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Telegram_B"/> class.
        /// </summary>
        public Telegram_B() : 
                this(true) {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Telegram_B"/> class.
        /// </summary>
        /// <param name="initWithDefaultValues">Determines whether the telegram should be initialized with default values.</param>
        public Telegram_B(bool initWithDefaultValues) {
            this.HEAD = new HeaderType();
            this.HEAD.MessageId = 44;
            this.HEAD.MessageLength = 66;
            if (initWithDefaultValues) {
                for (int index = 0; (index < 2); index++
                ) {
                    _int_1Byte[index] = 0;
                }
                for (int index = 0; (index < 2); index++
                ) {
                    _int_2Byte[index] = 0;
                }
                for (int index = 0; (index < 2); index++
                ) {
                    _int_4Byte[index] = 0;
                }
                for (int index = 0; (index < 2); index++
                ) {
                    _int_8Byte[index] = 0;
                }
                for (int index = 0; (index < 2); index++
                ) {
                    _integer_1Byte[index] = 0;
                }
                for (int index = 0; (index < 2); index++
                ) {
                    _integer_2Byte[index] = 0;
                }
                for (int index = 0; (index < 2); index++
                ) {
                    _integer_4Byte[index] = 0;
                }
                for (int index = 0; (index < 2); index++
                ) {
                    _integer_8Byte[index] = 0;
                }
            }
        }
        
        public static string HeaderXsbtDefinition {
            get {
                return Telegram_B._headerXsbtDefinition;
            }
        }
        
        public static string TelegramXsbtDefinition {
            get {
                return Telegram_B._telegramXsbtDefinition;
            }
        }
        
        /// <summary>
        /// Gets or sets the Header.
        /// </summary>
        /// <value>The HEAD.</value>
        [System.Xml.Serialization.XmlElement("HEAD", IsNullable=true)]
        public HeaderType HEAD {
            get {
                return this._hEAD;
            }
            set {
                this._hEAD = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the Int_1Byte. Unit: # with dimensions [2].
        /// </summary>
        /// <value>The Int_1Byte.</value>
        [System.Xml.Serialization.XmlElement("Int_1Byte", IsNullable=true)]
        public System.Byte?[] Int_1Byte {
            get {
                return this._int_1Byte;
            }
            set {
                if (((value != null) 
                            && (value.Length > 2))) {
                    throw new System.ArgumentOutOfRangeException("Int_1Byte", "Int_1Byte cannot handle arrays bigger than 2 elements.");
                }
                this._int_1Byte = new System.Byte?[2];
                if ((value != null)) {
                    System.Array.Copy(value, 0, this._int_1Byte, 0, System.Math.Min(2, value.Length));
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the Int_2Byte. Unit: # with dimensions [2].
        /// </summary>
        /// <value>The Int_2Byte.</value>
        [System.Xml.Serialization.XmlElement("Int_2Byte", IsNullable=true)]
        public System.Int16?[] Int_2Byte {
            get {
                return this._int_2Byte;
            }
            set {
                if (((value != null) 
                            && (value.Length > 2))) {
                    throw new System.ArgumentOutOfRangeException("Int_2Byte", "Int_2Byte cannot handle arrays bigger than 2 elements.");
                }
                this._int_2Byte = new System.Int16?[2];
                if ((value != null)) {
                    System.Array.Copy(value, 0, this._int_2Byte, 0, System.Math.Min(2, value.Length));
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the Int_4Byte. Unit: # with dimensions [2].
        /// </summary>
        /// <value>The Int_4Byte.</value>
        [System.Xml.Serialization.XmlElement("Int_4Byte", IsNullable=true)]
        public System.Int32?[] Int_4Byte {
            get {
                return this._int_4Byte;
            }
            set {
                if (((value != null) 
                            && (value.Length > 2))) {
                    throw new System.ArgumentOutOfRangeException("Int_4Byte", "Int_4Byte cannot handle arrays bigger than 2 elements.");
                }
                this._int_4Byte = new System.Int32?[2];
                if ((value != null)) {
                    System.Array.Copy(value, 0, this._int_4Byte, 0, System.Math.Min(2, value.Length));
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the Int_8Byte. Unit: # with dimensions [2].
        /// </summary>
        /// <value>The Int_8Byte.</value>
        [System.Xml.Serialization.XmlElement("Int_8Byte", IsNullable=true)]
        public System.Int64?[] Int_8Byte {
            get {
                return this._int_8Byte;
            }
            set {
                if (((value != null) 
                            && (value.Length > 2))) {
                    throw new System.ArgumentOutOfRangeException("Int_8Byte", "Int_8Byte cannot handle arrays bigger than 2 elements.");
                }
                this._int_8Byte = new System.Int64?[2];
                if ((value != null)) {
                    System.Array.Copy(value, 0, this._int_8Byte, 0, System.Math.Min(2, value.Length));
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the Integer_1Byte. Unit: # with dimensions [2].
        /// </summary>
        /// <value>The Integer_1Byte.</value>
        [System.Xml.Serialization.XmlElement("Integer_1Byte", IsNullable=true)]
        public System.Byte?[] Integer_1Byte {
            get {
                return this._integer_1Byte;
            }
            set {
                if (((value != null) 
                            && (value.Length > 2))) {
                    throw new System.ArgumentOutOfRangeException("Integer_1Byte", "Integer_1Byte cannot handle arrays bigger than 2 elements.");
                }
                this._integer_1Byte = new System.Byte?[2];
                if ((value != null)) {
                    System.Array.Copy(value, 0, this._integer_1Byte, 0, System.Math.Min(2, value.Length));
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the Integer_2Byte. Unit: # with dimensions [2].
        /// </summary>
        /// <value>The Integer_2Byte.</value>
        [System.Xml.Serialization.XmlElement("Integer_2Byte", IsNullable=true)]
        public System.Int16?[] Integer_2Byte {
            get {
                return this._integer_2Byte;
            }
            set {
                if (((value != null) 
                            && (value.Length > 2))) {
                    throw new System.ArgumentOutOfRangeException("Integer_2Byte", "Integer_2Byte cannot handle arrays bigger than 2 elements.");
                }
                this._integer_2Byte = new System.Int16?[2];
                if ((value != null)) {
                    System.Array.Copy(value, 0, this._integer_2Byte, 0, System.Math.Min(2, value.Length));
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the Integer_4Byte. Unit: # with dimensions [2].
        /// </summary>
        /// <value>The Integer_4Byte.</value>
        [System.Xml.Serialization.XmlElement("Integer_4Byte", IsNullable=true)]
        public System.Int32?[] Integer_4Byte {
            get {
                return this._integer_4Byte;
            }
            set {
                if (((value != null) 
                            && (value.Length > 2))) {
                    throw new System.ArgumentOutOfRangeException("Integer_4Byte", "Integer_4Byte cannot handle arrays bigger than 2 elements.");
                }
                this._integer_4Byte = new System.Int32?[2];
                if ((value != null)) {
                    System.Array.Copy(value, 0, this._integer_4Byte, 0, System.Math.Min(2, value.Length));
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the Integer_8Byte. Unit: # with dimensions [2].
        /// </summary>
        /// <value>The Integer_8Byte.</value>
        [System.Xml.Serialization.XmlElement("Integer_8Byte", IsNullable=true)]
        public System.Int64?[] Integer_8Byte {
            get {
                return this._integer_8Byte;
            }
            set {
                if (((value != null) 
                            && (value.Length > 2))) {
                    throw new System.ArgumentOutOfRangeException("Integer_8Byte", "Integer_8Byte cannot handle arrays bigger than 2 elements.");
                }
                this._integer_8Byte = new System.Int64?[2];
                if ((value != null)) {
                    System.Array.Copy(value, 0, this._integer_8Byte, 0, System.Math.Min(2, value.Length));
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the array of key column values.
        /// </summary>
        /// <value>The arrays of key column values.</value>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public object[] Keys {
            get {
                object[] keys = new object[20];
                return keys;
            }
            set {
                if (((value == null) 
                            || (value.Length < 0))) {
                    throw new System.ArgumentException();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the telegram Name.
        /// </summary>
        /// <value>The Name.</value>
        [System.Xml.Serialization.XmlAttributeAttribute("Name")]
        public string Name {
            get {
                return Telegram_B._name;
            }
            set {
                if (value != null && !value.Equals("Telegram_B")) {
throw new System.ArgumentException();
                }
                Telegram_B._name = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the telegram ID.
        /// </summary>
        /// <value>The ID.</value>
        [System.Xml.Serialization.XmlAttributeAttribute("ID")]
        public string ID {
            get {
                return Telegram_B._iD;
            }
            set {
                if ((value != "44")) {
throw new System.ArgumentException();
                }
                Telegram_B._iD = value;
            }
        }
        
        /// <summary>
        /// Gets the default id of this telegram.
        /// </summary>
        /// <value>The XML table name.</value>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public static string Id {
            get {
                return "44";
            }
        }
        
        /// <summary>
        /// Gets the fullname of telegram including namespace.
        /// </summary>
        /// <value>The fullname of telegram including namespace.</value>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string Fullname {
            get {
                return TelegramFullname;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Telegram_B"/> class.
        /// Deserializes specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>Deserialized instance of the <see cref="Telegram_B"/> class.</returns>
        public static Telegram_B Create(string xml) {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(Telegram_B));
            return (Telegram_B)xs.Deserialize(new System.IO.StringReader(xml));
        }
        
        /// <summary>
        /// Serializes this instance of the <see cref="Telegram_B"/> class and returns this xml as string.
        /// </summary>
        /// <returns>Serialized instance of this <see cref="Telegram_B"/> class.</returns>
        public string GetXml() {
            System.IO.StringWriter wr = new System.IO.StringWriter();
            new System.Xml.Serialization.XmlSerializer(typeof(Telegram_B)).Serialize(wr, this);
            return wr.ToString();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Telegram_B"/> class.
        /// Deserializes specified bytes array.
        /// </summary>
        /// <param name="bytes">The bytes array.</param>
        /// <returns>Deserialized instance of the <see cref="Telegram_B"/> class.</returns>
        public static Telegram_B Create(byte[] bytes) {
            if (string.IsNullOrEmpty(_telegramXsbtDefinition)) throw new System.NotSupportedException();
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(_headerXsbtDefinition);
            var typeMapping = new ProconTel.Mapping.TypeMapping(doc);
            var telegramHeader = ProconTel.Mapping.XsbtHeaderReader.ReadXml(_headerXsbtDefinition, typeMapping);
            var xsbtRegistry = new ProconTel.Mapping.BinaryXmlTranslator.XsbtRegistry(telegramHeader);
            xsbtRegistry.AddSchema(_telegramXsbtDefinition);
            var settings = ProconTel.Mapping.BinaryXmlTranslator.BinarySettings.Default;
            var translator = new ProconTel.Mapping.BinaryXmlTranslator.Translator(xsbtRegistry, typeMapping, new ProconTel.Mapping.BinaryXmlTranslator.BinaryBufferConverter { SwapBytes = settings.SwapBytes, InfinityValuesAccepted = settings.InfinityValuesAccepted }) { Settings = settings };
            Telegram_B telegram = new Telegram_B();
            translator.ConvertBufferToTelegramObject(translator.FindTelegramIdInBinaryData(bytes), telegram, bytes);
            return (Telegram_B)telegram;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Telegram_B"/> class.
        /// Deserializes specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Deserialized instance of the <see cref="Telegram_B"/> class.</returns>
        public static Telegram_B Create(object obj) {
            if(obj is string) return Create(obj.ToString());
            if(obj is byte[]) return Create((byte[])obj);
            return Create(obj.ToString());
        }
        
        /// <summary>
        /// Serializes this instance of the <see cref="Telegram_B"/> class and returns bytes array.
        /// </summary>
        /// <returns>Serialized instance of this <see cref="Telegram_B"/> class.</returns>
        public byte[] GetBytes() {
            if(string.IsNullOrEmpty(_telegramXsbtDefinition)) throw new System.NotSupportedException();
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(_headerXsbtDefinition);
            var typeMapping = new ProconTel.Mapping.TypeMapping(doc);
            var telegramHeader = ProconTel.Mapping.XsbtHeaderReader.ReadXml(_headerXsbtDefinition, typeMapping);
            var xsbtRegistry = new ProconTel.Mapping.BinaryXmlTranslator.XsbtRegistry(telegramHeader);
            var settings = ProconTel.Mapping.BinaryXmlTranslator.BinarySettings.Default;
            xsbtRegistry.AddSchema(_telegramXsbtDefinition);
            var translator = new ProconTel.Mapping.BinaryXmlTranslator.Translator(xsbtRegistry, typeMapping, new ProconTel.Mapping.BinaryXmlTranslator.BinaryBufferConverter { SwapBytes = settings.SwapBytes, InfinityValuesAccepted = settings.InfinityValuesAccepted }) { Settings = settings };
            return translator.ConvertTelegramObjectToBuffer(this);
        }
    }
}

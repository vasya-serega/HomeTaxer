using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;

namespace HomeTaxer.Client.Configuration
{
    /// <summary>
    /// Класс, содержащий настройки приложения
    /// паттерн сингл-тон
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Закрытый конструктор, чтобы нельзя было создать экземпляр класса
        /// </summary>
        private Config()
        { }

        /// <summary>
        /// Перезагружаем настройки
        /// </summary>
        public static void Reload()
        {
            instance = null;
        }

        /// <summary>
        /// Сохраняем класс
        /// </summary>
        public static void Save()
        {
            using (FileStream fs = new FileStream("Config.cfg", FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Config));
                xs.Serialize(fs, instance);
            }
        }

        /// <summary>
        /// Получаем копию класса настройки
        /// </summary>
        /// <returns></returns>
        public static Config GetClone()
        {
            return (Config)instance.MemberwiseClone();
        }

        /// <summary>
        /// Обновляем существующий экземпляр класса
        /// </summary>
        /// <param name="cfg">Экземпляр класса</param>
        public static void NewConfig(Config cfg)
        {
            instance = cfg;
        }

        /// <value>
        /// Получение экземпляра класса настройки
        /// </value>
        [XmlIgnore]
        public static Config Instance
        {
            get
            {
                lock (_lockFlag)
                {
                    if (instance == null)
                    {
                        try
                        {
                            //Пытаемся загрузить файл с диска и десериализовать его
                            using (FileStream fs = new FileStream("Config.cfg", FileMode.Open))
                            {
                                XmlSerializer xs = new XmlSerializer(typeof(Config));
                                instance = (Config)xs.Deserialize(fs);
                            }
                        }
                        catch 
                        {
                            //Если не удалось десериализовать то просто создаем новый экземпляр
                            instance = new Config();
                        }
                    }
                }
                return instance;
            }
        }

        #region AppllicationOptions
       
        ///// <value>
        ///// Папка, содержащая налоговые накладные
        ///// </value>
        //[DisplayName(" Директорія з необробленими файлами")]
        //[Category("Налаштування програми"), Description("Шлях до директорії, що містить необроблені документи"), Editor("System.Windows.Forms.Design.SelectedPathEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        //public string SourceDirectory
        //{
        //    get
        //    {
        //        if (_sourceDir.EndsWith(@"\"))
        //            return _sourceDir;
        //        else return _sourceDir + @"\";
        //    }
        //    set 
        //    { 
        //        _sourceDir = value.Trim(); 
        //    }
        //}

        /// <summary>
        /// Ім'я користувача
        /// </summary>
        [DisplayName("Ім'я користувача")]
        [Category("Налаштування програми")]
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value.Trim();
            }
        }

        /// <summary>
        /// Зберігати дані для входу?
        /// </summary>
        [DisplayName("Зберігати дані для входу?")]
        [Category("Налаштування програми")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool AllowSaveCredentials { get; set; } = false;

        /// <summary>
        /// Id рахунку за змовченням
        /// </summary>
        [Browsable(false)]
        public int AccountId { get; set; }

        /// <summary>
        /// Id валюти за змовченням
        /// </summary>
        [Browsable(false)]
        public int CurrencyId { get; set; } = 1;

        /// <summary>
        /// Валюти за змовченням
        /// </summary>
        [DisplayName("Валюта за змовченням")]
        [Category("Налаштування програми")]
        [ReadOnly(true)]
        public string Currency { get; set; }     

        #endregion

        private string _sourceDir = @"D:\temp\НДС\";

        private string _userName;

        private static object _lockFlag = new object();
        private static Config instance = Config.Instance;   //единственный экземпляр класса настройки

    }
}

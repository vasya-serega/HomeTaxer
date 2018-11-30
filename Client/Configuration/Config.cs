using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;

namespace HomeTaxer.Client.Configuration
{
    /// <summary>
    /// �����, ���������� ��������� ����������
    /// ������� �����-���
    /// </summary>
    public class Config
    {
        /// <summary>
        /// �������� �����������, ����� ������ ���� ������� ��������� ������
        /// </summary>
        private Config()
        { }

        /// <summary>
        /// ������������� ���������
        /// </summary>
        public static void Reload()
        {
            instance = null;
        }

        /// <summary>
        /// ��������� �����
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
        /// �������� ����� ������ ���������
        /// </summary>
        /// <returns></returns>
        public static Config GetClone()
        {
            return (Config)instance.MemberwiseClone();
        }

        /// <summary>
        /// ��������� ������������ ��������� ������
        /// </summary>
        /// <param name="cfg">��������� ������</param>
        public static void NewConfig(Config cfg)
        {
            instance = cfg;
        }

        /// <value>
        /// ��������� ���������� ������ ���������
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
                            //�������� ��������� ���� � ����� � ��������������� ���
                            using (FileStream fs = new FileStream("Config.cfg", FileMode.Open))
                            {
                                XmlSerializer xs = new XmlSerializer(typeof(Config));
                                instance = (Config)xs.Deserialize(fs);
                            }
                        }
                        catch 
                        {
                            //���� �� ������� ��������������� �� ������ ������� ����� ���������
                            instance = new Config();
                        }
                    }
                }
                return instance;
            }
        }

        #region AppllicationOptions
       
        ///// <value>
        ///// �����, ���������� ��������� ���������
        ///// </value>
        //[DisplayName(" ��������� � ������������� �������")]
        //[Category("������������ ��������"), Description("���� �� ��������, �� ������ ���������� ���������"), Editor("System.Windows.Forms.Design.SelectedPathEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
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
        /// ��'� �����������
        /// </summary>
        [DisplayName("��'� �����������")]
        [Category("������������ ��������")]
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
        /// �������� ��� ��� �����?
        /// </summary>
        [DisplayName("�������� ��� ��� �����?")]
        [Category("������������ ��������")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool AllowSaveCredentials { get; set; } = false;

        /// <summary>
        /// Id ������� �� ����������
        /// </summary>
        [Browsable(false)]
        public int AccountId { get; set; }

        /// <summary>
        /// Id ������ �� ����������
        /// </summary>
        [Browsable(false)]
        public int CurrencyId { get; set; } = 1;

        /// <summary>
        /// ������ �� ����������
        /// </summary>
        [DisplayName("������ �� ����������")]
        [Category("������������ ��������")]
        [ReadOnly(true)]
        public string Currency { get; set; }     

        #endregion

        private string _sourceDir = @"D:\temp\���\";

        private string _userName;

        private static object _lockFlag = new object();
        private static Config instance = Config.Instance;   //������������ ��������� ������ ���������

    }
}

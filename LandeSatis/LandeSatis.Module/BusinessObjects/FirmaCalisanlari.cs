using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LandeSatis.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Firma Çalışanları")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class FirmaCalisanlari : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public FirmaCalisanlari(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string _adi;
        [Index(0)] //Index sıralaması
        public string Adi
        {
            get { return _adi; }
            set { SetPropertyValue(nameof(Adi), ref _adi, value); }
        }

        private string _soyAdi;
        [Index(1)] //Index sıralaması
        public string SoyAdi
        {
            get { return _soyAdi; }
            set { SetPropertyValue(nameof(SoyAdi), ref _soyAdi, value); }
        }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public string TamIsim
        {
            get { return ObjectFormatter.Format("{Adi} {SoyAdi}", this, EmptyEntriesMode.RemoveDelimeterWhenEntryIsEmpty); }
        }

        private string _telefonNumarasi;
        [Index(2)] //Index sıralaması
        public string TelefonNumarasi
        {
            get { return _telefonNumarasi; }
            set { SetPropertyValue(nameof(TelefonNumarasi), ref _telefonNumarasi, value); }
        }
        public const string EmailRegularExpression = "^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$";
        private string _eMail;
        [Index(3)] //Index sıralaması
        [RuleRegularExpression(DefaultContexts.Save, FirmaCalisanlari.EmailRegularExpression, CustomMessageTemplate = "Geçersiz E-Posta Adresi")]
        public string EMail
        {
            get { return _eMail; }
            set { SetPropertyValue(nameof(EMail), ref _eMail, value); }
        }
        private Firmalar _firma;
        [Index(4)] //Index sıralaması
        [Association("Firmalar-FirmaCalisanlari")]
        public Firmalar Firma
        {
            get { return _firma; }
            set { SetPropertyValue(nameof(Firma), ref _firma, value); }
        }
        private Roller _rol;
        [Index(5)] //Index sıralaması
        public Roller Rol
        {
            get { return _rol; }
            set { SetPropertyValue(nameof(Rol), ref _rol, value); }
        }


        [XafDisplayName("Firma Çalışanları")]
        [Association("FirmaCalisanlari-WebKullanicilari")]
        public XPCollection<WebKullanicilari> Webkullanicis
        {

            get
            {
                return GetCollection<WebKullanicilari>(nameof(Webkullanicis));
            }
        }
    }
}
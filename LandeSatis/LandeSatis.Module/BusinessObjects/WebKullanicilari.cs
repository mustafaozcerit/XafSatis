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

    [XafDisplayName("Web Kullanıcıları")]
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class WebKullanicilari : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
      
        public WebKullanicilari(Session session)
            : base(session)
        {
        }
        
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _adi;
        //[Index(0)] //Index sıralaması
        //[RuleRequiredField("", DefaultContexts.Save, "")]
        //public string Adi
        //{
        //    get { return _adi; }
        //    set { SetPropertyValue(nameof(Adi), ref _adi, value); }
        //}

        //private string _soyAdi;
        //[Index(1)] //Index sıralaması
        //[RuleRequiredField("", DefaultContexts.Save, "")]
        //public string SoyAdi
        //{
        //    get { return _soyAdi; }
        //    set { SetPropertyValue(nameof(SoyAdi), ref _soyAdi, value); }
        //}
        //[Index(2)]
        //[VisibleInDetailView(false)]
        //[VisibleInListView(false)]

        //public string TamIsim
        //{
        //    get { return ObjectFormatter.Format("{Adi} {SoyAdi}", this, EmptyEntriesMode.RemoveDelimeterWhenEntryIsEmpty); }
        //}

        private string _kullaniciAdi;
        [Index(3)] //Index sıralaması
        [RuleRequiredField("", DefaultContexts.Save, "Kullanıcı Adı Boş Geçilemez")]
        [RuleUniqueValue]
        public string KullaniciAdi
        {
            get { return _kullaniciAdi; }
            set { SetPropertyValue(nameof(KullaniciAdi), ref _kullaniciAdi, value); }
        }
        private string _sifre;
        [Index(4)] //Index sıralaması
        [RuleRequiredField("", DefaultContexts.Save, "")]
        public string Sifre
        {
            get { return _sifre; }
            set { SetPropertyValue(nameof(Sifre), ref _sifre, value); }
        }

        private Roller _rol;
        [Index(5)] //Index sıralaması
        [RuleRequiredField("", DefaultContexts.Save, "")]
        public Roller Rol
        {
            get { return _rol; }
            set { SetPropertyValue(nameof(Rol), ref _rol, value); }

        }
        private FirmaCalisanlari _firmaCalisanlari;
        [Index(6)] //Index sıralaması
        [Association("FirmaCalisanlari-WebKullanicilari")]
        public FirmaCalisanlari FirmaCalisanlari
        {
            get { return _firmaCalisanlari; }
            set { SetPropertyValue(nameof(FirmaCalisanlari), ref _firmaCalisanlari, value); }

        }
        private string  _ekleyenKisi;
        [Index(7)] //Index sıralaması
        public string EkleyenKisi
        {
            get { return _ekleyenKisi; }
            set { SetPropertyValue(nameof(EkleyenKisi), ref _ekleyenKisi, value); }

        }
        private LandeKullanici _personel;
        [Index(7)] //Index sıralaması
        [Association("LandeKullanicilari-WebKullanicilari")]
        public LandeKullanici Personel
        {
            get { return _personel; }
            set { SetPropertyValue(nameof(Personel), ref _personel, value); }

        }
        private DateTime _Tarih;
        [RuleRequiredField]
        [XafDisplayName("Eklenme Tarihi")]
        public DateTime Tarih
        {
            get { return _Tarih; }
            set { SetPropertyValue<DateTime>(nameof(Tarih), ref _Tarih, value); }
        }

        //[XafDisplayName("Web Yetki Listesi")]
        //[Association("WebUser - YetkiList")]
        //public XPCollection<WebYetkiListesi> YetkiList
        //{
        //    get { return GetCollection<WebYetkiListesi>(nameof(YetkiList)); }
        //}

    }
}
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
    [XafDisplayName("Ürün Fiyatları")]
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class UrunFiyatlari : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public UrunFiyatlari(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private UrunAilesi _urunAilesi;
        [XafDisplayName("Ürün Ailesi"),RuleRequiredField]
        public UrunAilesi UrunAilesi
        {
            get { return _urunAilesi; }
            set { SetPropertyValue<UrunAilesi>(nameof(UrunAilesi), ref _urunAilesi, value); }
        }
        private UrunGrubu _urunGrubu;
        [XafDisplayName("Ürün Grubu"), RuleRequiredField, DataSourceProperty("UrunAilesi.UrunGrubus")]
        public UrunGrubu UrunGrubu
        {
            get { return _urunGrubu; }
            set { SetPropertyValue<UrunGrubu>(nameof(UrunGrubu), ref _urunGrubu, value); }
        }
        private UrunSerisi _urunSerisi;
        [XafDisplayName("Ürün Serisi"), DataSourceProperty("UrunGrubu.Seris")]
        public UrunSerisi UrunSerisi
        {
            get { return _urunSerisi; }
            set { SetPropertyValue<UrunSerisi>(nameof(UrunSerisi), ref _urunSerisi, value); }
        }

        private AlimSayisi _AlimSayisi;
        [XafDisplayName("Alım Sayı Aralığı")]
        public AlimSayisi AlimSayisi
        {
            get { return _AlimSayisi; }
            set { SetPropertyValue(nameof(AlimSayisi), ref _AlimSayisi, value); }
        }
        private YuzdeOrani yuzdeOrani;
        [XafDisplayName("Yüzdelik İndirim Oranı")]
        public YuzdeOrani YuzdeOrani
        {
            get { return yuzdeOrani; }
            set { SetPropertyValue(nameof(YuzdeOrani), ref yuzdeOrani, value); }
        }
        private DateTime _Tarih =DateTime.Now;
        [XafDisplayName("Eklenme Tarihi")]
        public DateTime Tarih
        {
            get { return _Tarih; }
            set { SetPropertyValue<DateTime>(nameof(Tarih), ref _Tarih, value); }
        }

        private Firmalar _Firma;
        [XafDisplayName("Firma Adı")]
        public Firmalar Firma
        {
            get { return _Firma; }
            set { SetPropertyValue(nameof(Firma), ref _Firma, value); }
        }

        private UrunSerisi _urun;
        [XafDisplayName("Ürün Serisi"), VisibleInDetailView(false), VisibleInListView(false),VisibleInLookupListView(false)]
        [Index(4)] //Index sıralaması
        [Association("UrunSerisi-UrunFiyatlari")]
        public UrunSerisi Urun
        {
            get { return _urun; }
            set { SetPropertyValue(nameof(Urun), ref _urun, value); }
        }
        [XafDisplayName("Ürün Fiyat Listesi")]
        [Association("UrunFiyatlari - UrunFiyatListesi")]
        public XPCollection<UrunFiyatListesi> UrunFiyatListesis
        {
            get { return GetCollection<UrunFiyatListesi>(nameof(UrunFiyatListesis)); }
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            Tarih = DateTime.Now;
        }
    }
}
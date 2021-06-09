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
    [XafDisplayName("Ürün Fiyatları Listesi")]
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class UrunFiyatListesi : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public UrunFiyatListesi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        private Urunler _urunOid;
        [XafDisplayName("Ürün")]
        public Urunler UrunOid
        {
            get { return _urunOid; }
            set { SetPropertyValue<Urunler>(nameof(UrunOid), ref _urunOid, value); }
        }
     
        private UrunFiyatlari _urun;
        [Association("UrunFiyatlari - UrunFiyatListesi"), XafDisplayName("Ürün Fyatları")]
        public UrunFiyatlari Urun
        {
            get { return _urun; }
            set { SetPropertyValue<UrunFiyatlari>(nameof(Urun), ref _urun, value); }
        }
        //private string _katalogKodu;
        //[XafDisplayName("Ürün Adı")]
        //public string KatalogKodu
        //{
        //    get { return _katalogKodu; }
        //    set { SetPropertyValue<string>(nameof(KatalogKodu), ref _katalogKodu, value); }
        //}
        private double _birimFiyat;
        [XafDisplayName("Birim Fiyatı")]
        public double BirimFiyat
        {
            get { return _birimFiyat; }
            set { SetPropertyValue<double>(nameof(BirimFiyat), ref _birimFiyat, value); }
        }
        //private string _aciklama;
        //[XafDisplayName("Ürün Açıklaması")]
        //public string Aciklama
        //{
        //    get { return _aciklama; }
        //    set { SetPropertyValue<string>(nameof(Aciklama), ref _aciklama, value); }
        //}
        private double _indirimliFiyat;
        [XafDisplayName("İndirimli Fiyat ")]
        public double IndirimliFiyat
        {
            get { return _indirimliFiyat; }
            set { SetPropertyValue<double>(nameof(IndirimliFiyat), ref _indirimliFiyat, value); }
        }
        private int _yuzdelikIndirim;
        [XafDisplayName("Yüzdelik İndirim ")]
        public int YuzdelikIndirim
        {
            get { return _yuzdelikIndirim; }
            set { SetPropertyValue<int>(nameof(YuzdelikIndirim), ref _yuzdelikIndirim, value); }
        }
        private string _alimSayisi;
        [XafDisplayName("Alım Sayısı")]
        public string AlimSayisi
        {
            get { return _alimSayisi; }
            set { SetPropertyValue<string>(nameof(AlimSayisi), ref _alimSayisi, value); }
        }
        private DateTime _Tarih;
        [RuleRequiredField]
        [XafDisplayName("Eklenme Tarihi")]
        public DateTime Tarih
        {
            get { return _Tarih; }
            set { SetPropertyValue<DateTime>(nameof(Tarih), ref _Tarih, value); }
        }
        private string _firma;
        [XafDisplayName("Firma")]
        public string Firma
        {
            get { return _firma; }
            set { SetPropertyValue<string>(nameof(Firma), ref _firma, value); }
        }
   
 //       [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit,
 //DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 30)]
 //       public byte[] LogoResmi
 //       {
 //           get { return GetPropertyValue<byte[]>(nameof(LogoResmi)); }
 //           set { SetPropertyValue<byte[]>(nameof(LogoResmi), value); }
 //       }
    }
}
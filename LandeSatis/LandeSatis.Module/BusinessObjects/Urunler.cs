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
using System.Drawing;
using System.Linq;
using System.Text;

namespace LandeSatis.Module.BusinessObjects
{
    [XafDisplayName("Ürünler")]
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Urunler : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Urunler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string _KatalogKodu;
        [XafDisplayName("Katalog Kodu")]
        public string KatalogKodu
        {
            get { return _KatalogKodu; }
            set { SetPropertyValue("KatalogKodu", ref _KatalogKodu, value); }
        }

        //private string _UrunAdi;
        //[XafDisplayName("Ürün Adı")]
        //public string UrunAdi
        //{
        //    get { return _UrunAdi; }
        //    set { SetPropertyValue("UrunAdi", ref _UrunAdi, value); }
        //}
        //private string _aciklama;
        //[XafDisplayName("Ürün Adı")]
        //public string Aciklama
        //{
        //    get { return _aciklama; }
        //    set { SetPropertyValue("Aciklama", ref _aciklama, value); }
        //}

        private string _StokKodu;
        [XafDisplayName("Stok Kodu")]
        public string StokKodu
        {
            get { return _StokKodu; }
            set { SetPropertyValue("StokKodu", ref _StokKodu, value); }
        }

        private string _Aciklama;
        [XafDisplayName("Ürün Açıklaması")]
        public string Aciklama
        {
            get { return _Aciklama; }
            set { SetPropertyValue("Aciklama", ref _Aciklama, value); }
        }

        private string _WebLink;
        [XafDisplayName("Ürün Linki")]
        public string WebLink
        {
            get { return _WebLink; }
            set { SetPropertyValue("WebLink", ref _WebLink, value); }
        }

        private UrunBoyutlari _netBoyut;
        [XafDisplayName("Net Boyutu")]
        public UrunBoyutlari NetBoyut
        {
            get { return _netBoyut; }
            set { SetPropertyValue("NetBoyut", ref _netBoyut, value); }
        }
        private string _netAgirlik;
        [XafDisplayName("Net Ağırlığı")]
        public string NetAgirlik
        {
            get { return _netAgirlik; }
            set { SetPropertyValue("NetAgirlik", ref _netAgirlik, value); }
        }

        private string _kuruluBoyut;
        [XafDisplayName("Kurulu Boyutu")]
        public string KuruluBoyut
        {
            get { return _kuruluBoyut; }
            set { SetPropertyValue("KuruluBoyut", ref _kuruluBoyut, value); }
        }
        private string _kuruluAgirlik;
        [XafDisplayName("Kurulu Ağırlığı")]
        public string KuruluAgirlik
        {
            get { return _kuruluAgirlik; }
            set { SetPropertyValue("KuruluAgirlik", ref _kuruluAgirlik, value); }
        }
        private string _kargoBoyut;
        [XafDisplayName("Kargo Boyutu")]
        public string KargoBoyut
        {
            get { return _kargoBoyut; }
            set { SetPropertyValue("KargoBoyut", ref _kargoBoyut, value); }
        }
        private string _kargoAgirlik;
        [XafDisplayName("Kargo Ağırlığı ")]
        public string KargoAgirlik
        {
            get { return _kargoAgirlik; }
            set { SetPropertyValue("KargoAgirlik", ref _kargoAgirlik, value); }
        }
        private UrunYukseklikleri _Yukseklik;
        [XafDisplayName("Yüksekliği")]
        public UrunYukseklikleri Yukseklik
        {
            get { return _Yukseklik; }
            set { SetPropertyValue("Yukseklik", ref _Yukseklik, value); }
        }

        private UrunRenkleri _Renk;
        [XafDisplayName("Renk")]
        public UrunRenkleri Renk
        {
            get { return _Renk; }
            set { SetPropertyValue("Renk", ref _Renk, value); }
        }

        private UrunAilesi _urunAilesi;
        [XafDisplayName("Ürün Ailesi")]
        public UrunAilesi urunAilesi
        {
            get { return _urunAilesi; }
            set { SetPropertyValue(nameof(urunAilesi), ref _urunAilesi, value); }
        }
        private UrunGrubu _urunGrubu;
        [XafDisplayName("Ürün Grubu"), DataSourceProperty("urunAilesi.UrunGrubus")]
        public UrunGrubu UrunGrubu
        {
            get { return _urunGrubu; }
            set { SetPropertyValue(nameof(UrunGrubu), ref _urunGrubu, value); }
        }
        private UrunSerisi _urunSeri;
        [XafDisplayName("Ürün Serisi"), DataSourceProperty("UrunGrubu.Seris")]
        [Association("Seri - Urun")]
        public UrunSerisi UrunSeri
        {
            get { return _urunSeri; }
            set { SetPropertyValue(nameof(UrunSeri), ref _urunSeri, value); }
        }
        private double _fiyat;
        [XafDisplayName("Ürün Fiyatı")]
        public double Fiyat
        {
            get { return _fiyat; }
            set { SetPropertyValue(nameof(Fiyat), ref _fiyat, value); }
        }
        [XafDisplayName("Ek Ürün")]
        [Association("Urunler - EkUrun")]
        public XPCollection<EkUrunler> EkUruns
        {
            get { return GetCollection<EkUrunler>(nameof(EkUruns)); }
        }


        //   [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit,
        //DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 30)]
        //   public byte[] LogoResmi
        //   {
        //       get { return GetPropertyValue<byte[]>(nameof(LogoResmi)); }
        //       set { SetPropertyValue<byte[]>(nameof(LogoResmi), value); }
        //   }
        private Image image, image1, iconImage, image2;
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public Image Image1
        {
            get { return image; }
            set { SetPropertyValue(nameof(Image1), ref image, value); }
        }

        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public Image Image2
        {
            get { return image1; }
            set { SetPropertyValue(nameof(Image2), ref image1, value); }
        }
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public Image Image3
        {
            get { return image2; }
            set { SetPropertyValue(nameof(Image3), ref image2, value); }
        }
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.DropDownPictureEdit,
     DetailViewImageEditorMode = ImageEditorMode.DropDownPictureEdit)]
        public byte[] Photo
        {
            get { return GetPropertyValue<byte[]>(nameof(Photo)); }
            set { SetPropertyValue<byte[]>(nameof(Photo), value); }
        }

    }
}
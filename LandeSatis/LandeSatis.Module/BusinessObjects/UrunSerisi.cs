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
    [XafDisplayName("Ürün Serisi")]
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class UrunSerisi : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public UrunSerisi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string _UrunSerisiAdi;
        [XafDisplayName("Ürün Serisi")]
        public string UrunSerisiAdi
        {
            get { return _UrunSerisiAdi; }
            set { SetPropertyValue(nameof(UrunSerisiAdi), ref _UrunSerisiAdi, value); }
        }

        [XafDisplayName("Ürün")]
        [Association("Seri - Urun")]
        public XPCollection<Urunler> Uruns
        {
            get { return GetCollection<Urunler>(nameof(Uruns)); }
        }
        private UrunGrubu _urunGrubu;
        [XafDisplayName("Ürün Grubu")]
        [Association("Grup - Seri"), VisibleInDetailView(false)]
        public UrunGrubu UrunGrub
        {
            get { return _urunGrubu; }
            set { SetPropertyValue(nameof(UrunGrub), ref _urunGrubu, value); }
        }
        [Association("UrunSerisi-UrunFiyatlari"), XafDisplayName("Ürün Fiyatları")]
        public XPCollection<UrunFiyatlari> UrunToFiyatlari
        {
            get
            {
                return GetCollection<UrunFiyatlari>(nameof(UrunToFiyatlari));
            }
        }
    }
}
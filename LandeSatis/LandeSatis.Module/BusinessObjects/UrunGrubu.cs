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
    [XafDisplayName("Ürün Grubu")]
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class UrunGrubu : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public UrunGrubu(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string _UrunGrubuAdi;
        [XafDisplayName("Ürün Grubu")]
        public string UrunGrubuAdi
        {
            get { return _UrunGrubuAdi; }
            set { SetPropertyValue(nameof(UrunGrubuAdi), ref _UrunGrubuAdi, value); }
        }
        [XafDisplayName("Urun Serisi")]
        [Association("Grup - Seri")]
        public XPCollection<UrunSerisi> Seris
        {
            get { return GetCollection<UrunSerisi>(nameof(Seris)); }
        }
        private UrunAilesi urunAilesi;
        [Association("Aile - Grup"), VisibleInDetailView(false)]
        public UrunAilesi UrunAilesi
        {
            get { return urunAilesi; }
            set { SetPropertyValue(nameof(UrunAilesi), ref urunAilesi, value); }
        }
    }
}
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
    [XafDisplayName("Ülkeler")]
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Ulkeler : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Ulkeler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string _tanim;
        [Size(300)]
        [Index(0)] //Index sıralaması
        public string Tanim
        {
            get { return _tanim; }
            set { SetPropertyValue(nameof(Tanim), ref _tanim, value); }
        }
        private string _kodu;
        [Size(3)]
        [Index(1)] //Index sıralaması
        public string Kodu
        {
            get { return _kodu; }
            set { SetPropertyValue(nameof(Kodu), ref _kodu, value); }
        }
        private string _telefonKodu;
        [Size(3)]
        [Index(2)] //Index sıralaması
        public string TelefonKodu
        {
            get { return _telefonKodu; }
            set { SetPropertyValue(nameof(TelefonKodu), ref _telefonKodu, value); }
        }
        [Association("Ulkeler-Sehirlers")]
        public XPCollection<Sehirler> Sehirlers
        {

            get
            {
                return GetCollection<Sehirler>(nameof(Sehirlers));
            }
        }
    }
}
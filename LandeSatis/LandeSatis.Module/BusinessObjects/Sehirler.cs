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
    [XafDisplayName("Şehirler")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Sehirler : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Sehirler(Session session)
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
        private string _alanKodu;
        [Size(300)]
        [Index(1)] //Index sıralaması
        public string AlanKodu
        {
            get { return _alanKodu; }
            set { SetPropertyValue(nameof(AlanKodu), ref _alanKodu, value); }
        }
        private Ulkeler _ulkeID;
        [XafDisplayName("Ülke")]
        [Index(2)] //Index sıralaması
        [Association("Ulkeler-Sehirlers")]
        public Ulkeler UlkeID
        {
            get { return _ulkeID; }
            set { SetPropertyValue(nameof(UlkeID), ref _ulkeID, value); }
        }
    }
}
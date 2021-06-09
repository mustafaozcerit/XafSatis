using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
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
    [XafDisplayName("Lande Kullanıcıları")]
    public class LandeKullanici : PermissionPolicyUser
    { 
        public LandeKullanici(Session session)
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
        [XafDisplayName("Firma Çalışanları")]
        [Association("LandeKullanicilari-WebKullanicilari")]
        public XPCollection<WebKullanicilari> Webkullanicis
        {

            get
            {
                return GetCollection<WebKullanicilari>(nameof(Webkullanicis));
            }
        }
    }
}
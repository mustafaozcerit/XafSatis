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
    [XafDisplayName("Web Yetki Listesi")]
    public class WebYetkiListesi : BaseObject
    { 
        public WebYetkiListesi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }





        private string _yetki;
        [XafDisplayName("Yetki")]
        public string Yetki
        {
            get { return _yetki; }
            set { SetPropertyValue(nameof(Yetki), ref _yetki, value); }
        }
        
        private string _Rol;
        [XafDisplayName("Yetki")]
        public string Rol
        {
            get { return _Rol; }
            set { SetPropertyValue(nameof(Rol), ref _Rol, value); }
        }
        private Roller _yetkirol;
        [Association("Roller - Yetki")]
        public Roller Yetkirol
        {
            get { return _yetkirol; }
            set { SetPropertyValue(nameof(Yetkirol), ref _yetkirol, value); }
        }
        //private WebKullanicilari _webKullanicilari;
        //[Index(3)] //Index sıralaması
        //[Association("WebUser - YetkiList")]
        //public WebKullanicilari WebKullanicilari
        //{
        //    get { return _webKullanicilari; }
        //    set { SetPropertyValue(nameof(WebKullanicilari), ref _webKullanicilari, value); }
        //}
    }
}
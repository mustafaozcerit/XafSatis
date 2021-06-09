using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using LandeSatis.Module.BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandeSatis.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FiyatController : ViewController
    {
        IList urunList;
        IObjectSpace newobj;
        public FiyatController()
        {
            InitializeComponent();
            popupWindowShowAction1.TargetViewId = "UrunFiyatlari_DetailView";
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        public UrunFiyatlari proje;
        public UrunFiyatListesi urunFiyatListesi;
        private void popupWindowShowAction1_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace();

            urunList = e.PopupWindowViewSelectedObjects;

            //foreach (UrunSerisi item in urunSeriList)
            //{
            //    foreach (Urunler modul in item.Uruns)
            //    {
            //        UrunFiyatListesi urunFiyatListesi = ObjectSpace.CreateObject(typeof(UrunFiyatListesi)) as UrunFiyatListesi;

            //        UrunFiyatlari proje = View.CurrentObject as UrunFiyatlari;
            //        //urunFiyatListesi.KatalogKodu = modul.KatalogKodu;
            //        //UrunSerisi a = new UrunSerisi(ObjectSpace.GetObject<>)
            //        urunFiyatListesi.UrunOid = modul;
            //        urunFiyatListesi.UrunSerisis = ObjectSpace.GetObject(modul.UrunSeri);
            //        urunFiyatListesi.UrunAilesis = proje.UrunAilesi;
            //        urunFiyatListesi.UrunGrubu = proje.UrunGrubu;
            //        //urunFiyatListesi.UrunSerisi = item.UrunSerisiAdi;
            //        urunFiyatListesi.BirimFiyat = modul.Fiyat;
            //        urunFiyatListesi.IndirimliFiyat = ((modul.Fiyat) * (100 - (proje.YuzdeOrani.Oran)) / 100);
            //        urunFiyatListesi.AlimSayisi = proje.AlimSayisi.SayiAraligi;
            //        urunFiyatListesi.YuzdelikIndirim = proje.YuzdeOrani.Oran;
            //        urunFiyatListesi.Firma = proje.Firma.FirmaAdi;
            //        //urunFiyatListesi.Tarih = DateTime.Now;
            //        //urunFiyatListesi.LogoResmi= modul.LogoResmi;
            //        //urunFiyatListesi.Aciklama = modul.Aciklama;
            //        DateTime Currentdate = DateTime.Now;
            //        urunFiyatListesi.Tarih = DateTime.Now;
            //        proje.UrunFiyatListesis.Add(urunFiyatListesi);
            //        proje.Save();

            //    }
            //}

            foreach (Urunler item in urunList)
            {
                
                    urunFiyatListesi = ObjectSpace.CreateObject(typeof(UrunFiyatListesi)) as UrunFiyatListesi;
                    urunFiyatListesi.UrunOid = ObjectSpace.GetObject(item);
                    proje = View.CurrentObject as UrunFiyatlari;
                    urunFiyatListesi.BirimFiyat = item.Fiyat;
                    urunFiyatListesi.IndirimliFiyat = ((item.Fiyat) * (100 - (proje.YuzdeOrani.Oran)) / 100);
                    urunFiyatListesi.AlimSayisi = proje.AlimSayisi.SayiAraligi;
                    urunFiyatListesi.YuzdelikIndirim = proje.YuzdeOrani.Oran;
                    urunFiyatListesi.Firma = proje.Firma.FirmaAdi;
                    urunFiyatListesi.Tarih = DateTime.Now;
                    proje.UrunFiyatListesis.Add(urunFiyatListesi);
                    proje.Save();

                
            }
        }

        private void popupWindowShowAction1_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace newobj = Application.CreateObjectSpace(typeof(Urunler));
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(UrunFiyatListesi));
            UrunFiyatlari obj = View.CurrentObject as UrunFiyatlari;
            string ListViewId = Application.FindListViewId(typeof(Urunler));
            CollectionSourceBase collectionSource = Application.CreateCollectionSource(newobj, typeof(Urunler), ListViewId);

            if (obj.UrunSerisi != null)
            {
                CriteriaOperator criteriaHasta = CriteriaOperator.Parse("UrunSerisi= ?", proje.UrunSerisi.Oid);
                IList fiyatList = objectSpace.GetObjects(typeof(UrunFiyatListesi));
                //urunFiyatListesi.Urun.UrunSerisi






                collectionSource.Criteria["CustomCriteria"] = new BinaryOperator("UrunSeri.UrunSerisiAdi", obj.UrunSerisi.UrunSerisiAdi);
                ListView listView = Application.CreateListView(ListViewId, collectionSource, true);
                listView.AllowEdit["Allow"] = true;
                e.View = listView;
            }
            else
            {
                MessageOptions options = new MessageOptions();
                options.Duration = 10000;
                options.Message = "Hatalı İşlem Lütfen Bilgileri Eksiksiz Girdiğinizden Emin Olup Tekrar Deneyin !";
                options.Web.Position = InformationPosition.Bottom;
                options.Type = InformationType.Error;
                options.Win.Caption = "";
                Application.ShowViewStrategy.ShowMessage(options);
            }



        }
    }
}

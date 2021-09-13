using System;
using System.Collections.Generic;
using AllegroApi.Domain.AllegroOffer;
using AllegroApi.Domain.AllegroOffer.AdditionalServices;
using AllegroApi.Domain.AllegroOffer.AfterSalesServices;
using AllegroApi.Domain.AllegroOffer.Category;
using AllegroApi.Domain.AllegroOffer.Description;
using AllegroApi.Domain.AllegroOffer.External;
using AllegroApi.Domain.AllegroOffer.Image;
using AllegroApi.Domain.AllegroOffer.Parameter;
using AllegroApi.Domain.AllegroOffer.Price;
using AllegroApi.Domain.AllegroOffer.SellingMode;
using AllegroApi.Domain.AllegroOffer.Stock;

namespace AllegroApi.Builders
{
    public class OfferDraftBuilder
    {
        private NewOffer _newOffer;

        public NewOffer Build()
        {
            return _newOffer;
        }

        public void SetName(string name)
        {
            _newOffer.Name = name;
        }

        public void SetCategory(string categoryId)
        {
            _newOffer.Category = new Category()
            {
                Id = categoryId
            };
        }

        public void SetPrimaryImage(Uri uri)
        {
            _newOffer.PrimaryImage = new PrimaryImage()
            {
                Url = uri.ToString()
            };
        }

        public void SetSellingMode(SellingMode sellingMode)
        {
            _newOffer.SellingMode = sellingMode;
        }

        public void SetSaleInfo(SaleInfo saleInfo)
        {
            _newOffer.SaleInfo = saleInfo;
        }

        public void SetStock(int available, string unit)
        {
            _newOffer.Stock = new Stock()
            {
                Available = available,
                Unit = unit
            };
        }

        public void SetAfterSalesServices(string impliedWarrantyId, string returnPolicyId, string warrantyId)
        {
            _newOffer.AfterSalesServices = new AfterSalesServices()
            {
                ImpliedWarranty = new ImpliedWarranty() {Id = impliedWarrantyId},
                ReturnPolicy = new ReturnPolicy() {Id = returnPolicyId},
                Warranty = new Warranty() {Id = warrantyId},
            };
        }
        
        public void SetAdditionalServices(string id)
        {
            _newOffer.AdditionalServices = new AdditionalServices
            {
                 Id = id
            };
        }
        
        public void SetExternal(string id)
        {
            _newOffer.External = new External
            {
                Id = id
            };
        }
        
        public void SetParameters(List<Parameter> parameter)
        {
            _newOffer.Parameters = parameter;
        }
        
        //TODO: dodać obiekt produkt
        public void SetProduct(object product)
        {
            _newOffer.Product = product;
        }
        //TODO: dodać obiekt Ean
        public void SeEan(object ean)
        {
            _newOffer.Ean = ean;
        }
        //TODO: dodać obiekt CompatibilityList
        public void SeCompatibilityList(object compatibilityList)
        {
            _newOffer.CompatibilityList = compatibilityList;
        }
        
        public void SetDescription(Description description)
        {
            _newOffer.Description = description;
        }
        

    }
}
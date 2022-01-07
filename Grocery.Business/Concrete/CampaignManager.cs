using Grocery.Business.Abstract;
using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private ICampaignService _campaignService;
        public CampaignManager(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public void Create(Campaign entity)
        {
            _campaignService.Create(entity);
        }

        public void Delete(Campaign entity)
        {
            _campaignService.Delete(entity);
        }

        public List<Campaign> GetAll()
        {
            return _campaignService.GetAll();
        }

        public Campaign GetById(int id)
        {
            return _campaignService.GetById(id);
        }

        public void Update(Campaign entity)
        {
            _campaignService.Update(entity);
        }
    }
}

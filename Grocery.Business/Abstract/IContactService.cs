﻿using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Business.Abstract
{
    public interface IContactService
    {
        Contact GetById(int id);
        List<Contact> GetAll();
        void Create(Contact entity);
        void Delete(Contact entity);
    }
}

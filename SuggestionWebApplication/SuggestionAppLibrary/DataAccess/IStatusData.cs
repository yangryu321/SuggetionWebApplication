﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SuggestionAppLibrary.Models;

namespace SuggestionAppLibrary.DataAccess
{
    public interface IStatusData
    {
        Task CreateStatus(StatusModel status);
        Task<List<StatusModel>> GetAllStatuses();
    }
}
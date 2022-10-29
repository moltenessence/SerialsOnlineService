﻿using SerialsOnlineService.BLL.Interface.Models;

namespace SerialsOnlineService.BLL.Models
{
    public record Rating(int Id = default, int Value = default, string? Annotation = null) : IModel;
}

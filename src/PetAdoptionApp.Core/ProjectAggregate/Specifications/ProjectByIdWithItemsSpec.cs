﻿using Ardalis.Specification;
using PetAdoptionApp.Core.ProjectAggregate;

namespace PetAdoptionApp.Core.ProjectAggregate.Specifications;
public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
    public ProjectByIdWithItemsSpec(int projectId)
    {
        Query
                .Where(project => project.Id == projectId)
                .Include(project => project.Items);
    }
}

﻿using CollegeManagement.Infrastructure.Repositories.Interfaces;
using CollegeManagement.Web.data;
using CollegeManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Infrastructure.Repositories;
public class MajorsRepository : IMajorRepository
{
    private readonly CollegeDbContext db;

    public MajorsRepository(CollegeDbContext _db)
    {
        db = _db;
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task Edit(Major student)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Major> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Major>> GetAll(string searchText = "")
    {
        List<Major> majors = await db.Majors.ToListAsync();
        return majors;
    }

    public Task Insert(Major student)
    {
        throw new NotImplementedException();
    }
}
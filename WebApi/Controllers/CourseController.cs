﻿using Abp.Domain.Uow;
using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _courseManager;
        //public IUnitOfWork _unitOfWork;
        // define the mapper
        public readonly IMapper _mapper;
        public CourseController(ICourseManager courseManager, IMapper mapper)
        {
            _courseManager = courseManager;
            _mapper = mapper;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            JsonResult res = new(new { });
            var courseList = await _courseManager.PopularCourses();
            var _mapperCourse = _mapper.Map<List <CourseListDTO>>(courseList);
            res.Value = _mapperCourse;
            return res;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public CourseDetailDTO? Get(int? id)
        {
            if(!id.HasValue) return null;
            var singleCourse = _courseManager.CourseId(id.Value);
            var _courseMapper=_mapper.Map<CourseDetailDTO>(singleCourse);

            return _courseMapper;
        }

        // POST api/<CourseController>
        [HttpPost]
        public  async Task Post([FromBody] CourseDetailDTO courseDetailDTO)
        {
            var _mapperCourse=_mapper.Map<Course>(courseDetailDTO);
            await _courseManager.CourseAdded(_mapperCourse);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using PhoneBookHumanGroupBL.InterfacesOfManagers;
using PhoneBookHumanGroupEL.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhoneBookHumanGroupDL.InterfacesofRepos;
using AutoMapper;

namespace PhoneBookHumanGroupBL.ImplementationsOfManagers
{
    public class Manager<TViewModel, TModel, Tid> : IManager<TViewModel, Tid>
        where TViewModel : class, new()
        where TModel : class, new()
    {

        protected readonly IRepository<TModel, Tid> _repo;
        protected readonly IMapper _mapper;
        protected readonly string[] _joinTablesName;

        public Manager(IRepository<TModel, Tid> repo, IMapper mapper, string[] joinTablesName)
        {
            _repo = repo;
            _mapper = mapper;
            _joinTablesName = joinTablesName;
        }

        public IDataResult<TViewModel> Add(TViewModel entity)
        {
            try
            {
                //Ekleme işlemi repoda yapılıyor
                var data = _mapper.Map<TViewModel, TModel>(entity);

                if (_repo.Add(data) > 0)
                {
                    var sonuc = new DataResult<TViewModel>();
                    sonuc.IsSuccess = true;
                    sonuc.Message = "Ekleme başarıldır!";
                    sonuc.Data = _mapper.Map<TModel, TViewModel>(data);
                    return sonuc;
                }
                else
                {
                    return new DataResult<TViewModel>(false, "Ekleme işlemi başarısızdır! Tekrar deneyiniz!", null);
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IResult Delete(TViewModel entity)
        {
            try
            {
                var data = _mapper.Map<TViewModel, TModel>(entity);
                if (_repo.Delete(data) > 0)
                {

                    var gonderilecekData = _mapper.Map<TModel, TViewModel>(data);
                    return new DataResult<TViewModel>(true, "Silme işlemi başarılıdır!", gonderilecekData);
                }
                else
                {
                    var sonuc = new DataResult<TViewModel>();
                    sonuc.IsSuccess = false;
                    sonuc.Message = "Silme işlemi başarısız oldu! Tekrar deneyiniz!";
                    sonuc.Data = null;
                    return sonuc;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<ICollection<TViewModel>> GetAll(Expression<Func<TViewModel, bool>>? whereFilter = null, string[]? joinTablesName = null)
        {
            try
            {
                if (_joinTablesName != null)
                {
                    joinTablesName = _joinTablesName;
                }

                var allData = _repo.GetAll(_mapper.Map<Expression<Func<TViewModel, bool>>,
                    Expression<Func<TModel, bool>>>(whereFilter), joinTablesName);

                if (allData == null)
                {
                    return new DataResult<ICollection<TViewModel>>(false, "Veriler bulunamadı!", null);
                }
                else
                {
                    var sonuc = _mapper.Map<IQueryable<TModel>, ICollection<TViewModel>>(allData);
                    return new DataResult<ICollection<TViewModel>>(true, $"{sonuc.Count} adet veri bulundu!", sonuc);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<TViewModel> GetByCondition(Expression<Func<TViewModel, bool>>? whereFilter = null, string[]? joinTablesName = null)
        {
            try
            {

                if (_joinTablesName != null)
                {
                    joinTablesName = _joinTablesName;
                }
                var filter = _mapper.Map<Expression<Func<TViewModel, bool>>,
                    Expression<Func<TModel, bool>>>(whereFilter);
                var data = _repo.GetByCondition(filter, joinTablesName);

                return data == null ?
                    new DataResult<TViewModel>(false, "", null)
                    :
                    new DataResult<TViewModel>(true, "", _mapper.Map<TModel, TViewModel>(data))
                    ;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<TViewModel> GetbyId(int Tid)
        {
            try
            {
                var data = _repo.GetbyId(Tid);
                if (data != null)
                {
                    return new DataResult<TViewModel>(true, "Veri Bulundu!", _mapper.Map<TModel, TViewModel>(data));
                }
                else
                {
                    return new DataResult<TViewModel>(false, "Veri Bulunamadı!", null);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<TViewModel> Update(TViewModel entity)
        {
            try
            {
                var data = _mapper.Map<TViewModel, TModel>(entity);
                return _repo.Update(data) > 0 ?
                     new DataResult<TViewModel>(true, "Güncelleme başarıldır!", _mapper.Map<TModel, TViewModel>(data))
                     :
                      new DataResult<TViewModel>(false, "Güncelleme işleminde hata oluştu! Tekrar deneyiniz!", null);
                ;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

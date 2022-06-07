using Microsoft.EntityFrameworkCore;
using REGNEWAPI.Models;
using REGNEWAPI.Repository;
namespace REGNEWAPI.Repository
{
    public interface NewInterface
    {
        List<ApiModel> Get();
        bool Create(ApiModel Mac);
        void Delete(int id);
        ApiModel Edit(int id);
    }
    public abstract class Repo : NewInterface
    {
        public abstract List<ApiModel> Get();

        public abstract bool Create(ApiModel Mac);

        public abstract void Delete(int id);

        public abstract ApiModel Edit(int id);


    }

    public class IFisrtRepository : Repo
    {

        private readonly Apicontext dbcontext;
        public IFisrtRepository(Apicontext _db)
        {
            dbcontext = _db;
        }

        public override List<ApiModel> Get()
        {
            return dbcontext.MVCDemo7.ToList();
        }


        public override bool Create(ApiModel Mac)
        {
            if (Mac == null)
            {
                return false;
            }
            else
            {
                if (Mac.Id == 0)
                {
                    dbcontext.MVCDemo7.Add(Mac);
                    dbcontext.SaveChanges();
                    return true;
                }
                else
                {
                    dbcontext.Entry(Mac).State = EntityState.Modified;
                    dbcontext.SaveChanges();
                    return true;
                }
            }

        }

        public override void Delete(int id)
        {
            var student = dbcontext.MVCDemo7.Find(id);
            dbcontext.MVCDemo7.Remove(student);
            dbcontext.SaveChangesAsync();
            return;
        }

        public override ApiModel Edit(int id)
        {
            return dbcontext.MVCDemo7.Find(id);
        }
    }
}

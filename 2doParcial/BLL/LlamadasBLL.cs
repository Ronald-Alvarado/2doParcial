using _2doParcial.DAL;
using _2doParcial.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Media.Animation;

namespace _2doParcial.BLL
{
    public class LlamadasBLL
    {
        public static bool Guardar(Llamadas llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if(db.Llamadas.Add(llamada) != null)
                {
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Llamadas llamadas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"DELETE FROM LlamadasDetalle WHERE LlamadaId={llamadas.LlamadaId}");

                foreach(var item in llamadas.LlamadasDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(llamadas).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = db.Llamadas.Find(Id);
                db.Entry(Eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Llamadas Buscar(int Id)
        {
            Llamadas llamada = new Llamadas();
            Contexto db = new Contexto();

            try
            {
                llamada = db.Llamadas.Include(x => x.LlamadasDetalle).Where(x => x.LlamadaId == Id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return llamada;
        }
    }
}

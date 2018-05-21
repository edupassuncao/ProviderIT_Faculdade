using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FaculdadeXPTO.DAL;
using FaculdadeXPTO.Models;

namespace FaculdadeXPTO.Controllers
{
    public class TurmasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Turmas
        public ActionResult Index()
        {
            return View(db.Turmas.ToList());
        }

        // GET: Turmas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = db.Turmas.Find(id);

            //detalhe
            var IdsDisciplinas = db.Turma_Disciplinas.Where(x => x.IdTurma == turma.Id).Select(x => x.IdDisciplina).ToList();
            turma.disciplinas = db.Disciplinas.Where(x => IdsDisciplinas.Contains(x.Id)).ToList();

            var IdsAlunos = db.Turma_Alunos.Where(x => x.IdTurma == turma.Id).Select(x => x.IdAluno).ToList();
            turma.alunos = db.Alunos.Where(x => IdsAlunos.Contains(x.Id)).ToList();


            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // GET: Turmas/Create
        public ActionResult Create()
        {
            var turma = new Turma();

            turma.disciplinas = db.Disciplinas.ToList();

            turma.alunos = db.Alunos.ToList();

            return View(turma);
        }

        // POST: Turmas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Turmas.Add(turma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(turma);
        }


        [HttpPost]
        public ActionResult SalvarTurma(string NomeTurma, int[] Disciplinas, int[] Alunos)
        {
            var turma = new Turma();

            turma.Nome = NomeTurma;

            db.Turmas.Add(turma);

            db.SaveChanges();

            var turma_aluno = new List<Turma_Aluno>();

            foreach (var item in Alunos)
            {
                turma_aluno.Add(new Turma_Aluno() { IdAluno = item, IdTurma = turma.Id });
            }

            db.Turma_Alunos.AddRange(turma_aluno);

            db.SaveChanges();


            var turma_disciplina = new List<Turma_Disciplina>();

            foreach (var item in Disciplinas)
            {
                turma_disciplina.Add(new Turma_Disciplina() { IdDisciplina = item, IdTurma = turma.Id });
            }

            db.Turma_Disciplinas.AddRange(turma_disciplina);

            db.SaveChanges();


            return RedirectToAction("Index");


        }


        // GET: Turmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = db.Turmas.Find(id);

            var IdsDisciplinas = db.Turma_Disciplinas.Where(x => x.IdTurma == turma.Id).Select(x => x.IdDisciplina).ToList();

            var IdsAlunos = db.Turma_Alunos.Where(x => x.IdTurma == turma.Id).Select(x => x.IdAluno).ToList();

            turma.disciplinas = db.Disciplinas.ToList();

            turma.alunos = db.Alunos.ToList();

            foreach (var item in turma.disciplinas)
            {
                item.IsChecked = IdsDisciplinas.Contains(item.Id);
            }

            foreach (var item in turma.alunos)
            {
                item.IsChecked = IdsAlunos.Contains(item.Id);
            }
         
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarTurma(int id, int[] Disciplinas, int[] Alunos, string NomeTurma)
        {
            Turma turma = new Turma();

            if (ModelState.IsValid)
            {

                turma.Id = id;

                turma.Nome = NomeTurma;

                db.Entry(turma).State = EntityState.Modified;

                //turma_diisciplina
                var turmadis = db.Turma_Disciplinas.Where(x => x.IdTurma == id).ToList();

                db.Turma_Disciplinas.RemoveRange(turmadis);

                var turma_disciplina = new List<Turma_Disciplina>();

                foreach (var item in Disciplinas)
                {
                    turma_disciplina.Add(new Turma_Disciplina() { IdDisciplina = item, IdTurma = id });
                }

                db.Turma_Disciplinas.AddRange(turma_disciplina);

                db.SaveChanges();


                //Turma Aluno
                var turmaaluno = db.Turma_Alunos.Where(x => x.IdTurma == id).ToList();

                db.Turma_Alunos.RemoveRange(turmaaluno);


                var turma_aluno = new List<Turma_Aluno>();

                foreach (var item in Alunos)
                {
                    turma_aluno.Add(new Turma_Aluno() { IdAluno = item, IdTurma = id });
                }

                db.Turma_Alunos.AddRange(turma_aluno);

                db.SaveChanges();

                
                return RedirectToAction("Index");

            }

            return View(turma);
        }

        // GET: Turmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = db.Turmas.Find(id);

            //detalhe
            var IdsDisciplinas = db.Turma_Disciplinas.Where(x => x.IdTurma == turma.Id).Select(x => x.IdDisciplina).ToList();
            turma.disciplinas = db.Disciplinas.Where(x => IdsDisciplinas.Contains(x.Id)).ToList();

            var IdsAlunos = db.Turma_Alunos.Where(x => x.IdTurma == turma.Id).Select(x => x.IdAluno).ToList();
            turma.alunos = db.Alunos.Where(x => IdsAlunos.Contains(x.Id)).ToList();


            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var turmaAluno = db.Turma_Alunos.Where(x => x.IdTurma == id).ToList();
            db.Turma_Alunos.RemoveRange(turmaAluno);

            var turmaDisciplina = db.Turma_Disciplinas.Where(x => x.IdTurma == id).ToList();
            db.Turma_Disciplinas.RemoveRange(turmaDisciplina);

            db.SaveChanges();

            Turma turma = db.Turmas.Find(id);
            db.Turmas.Remove(turma);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

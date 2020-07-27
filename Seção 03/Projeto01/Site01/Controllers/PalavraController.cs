﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site01.Database;
using Site01.Library.Filters;
using Site01.Models;
using X.PagedList;

namespace Site01.Controllers
{
    [Login]
    public class PalavraController : Controller
    {

        List<Nivel> niveis = new List<Nivel>();

        private DatabaseContext _db;
        public PalavraController(DatabaseContext db)
        {
            _db = db;


            niveis.Add(new Nivel() { Id = 1, Nome = "Fácil" });
            niveis.Add(new Nivel() { Id = 2, Nome = "Médio" });
            niveis.Add(new Nivel() { Id = 3, Nome = "Difícil" });
        }

        //Listar todas as palavras do banco de dados
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var palavras = _db.Palvras.ToList();
            var resultadoPaginado = palavras.ToPagedList(pageNumber, 5);


            return View(resultadoPaginado);
        }

        //CRUD - Cadastrar, Consultar, Atualizar e Contruir. Create Reatrive, Update, Delete - CRUD
        [HttpGet]
        public IActionResult Cadastrar()
        {

            ViewBag.Nivel = niveis;
            return View(new Palavra());
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Palavra palavra)
        {
            ViewBag.Nivel = niveis;
            if (ModelState.IsValid)
            {
                _db.Palvras.Add(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = "A palavra '" + palavra.Nome + "' foi cadastrada com sucesso!";

                return RedirectToAction("Index");
            }

            return View(palavra);
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            ViewBag.Nivel = niveis;
            Palavra palavra = _db.Palvras.Find(id);


            return View("Cadastrar", palavra);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Palavra palavra)
        {
            ViewBag.Nivel = niveis;
            if (ModelState.IsValid)
            {
                _db.Palvras.Update(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = "A palavra '" + palavra.Nome + "' foi atualizada com sucesso!";

                return RedirectToAction("Index");
            }
            return View("Cadastrar", palavra);
        }


        //Palavra/Excluir/39
        //{controller}/{Action}/{Id?}
        [HttpGet]
        public IActionResult Excluir(int Id)
        {
            Palavra palavra = _db.Palvras.Find(Id);
            _db.Palvras.Remove(palavra);
            _db.SaveChanges();

            TempData["Mensagem"] = "A palavra '" + palavra.Nome + "' foi excluida com sucesso!";

            return RedirectToAction("Index");
        }
    }
}

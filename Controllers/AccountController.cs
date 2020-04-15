using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WADProject.Data;
using WADProject.Models;
using WADProject.Repositories;
using WADProject.Repositories.Abstractions;

namespace WADProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountRepository accounts;
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(IAccountRepository accounts, UserManager<IdentityUser> userManager)
        {
            this.accounts = accounts;
            this.userManager = userManager;
        }

        // GET: Account
        public async Task<IActionResult> Index()
        {
            // return View(await _context.Accounts.ToListAsync());
            return View(accounts.GetUserAccounts(await userManager.GetUserAsync(User)));
        }

        // GET: Account/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var account = accounts.Get(id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("Id,Balance")] Account account)
        {
            if (ModelState.IsValid)
            {
                account.User = await userManager.GetUserAsync(User);
                accounts.Add(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Account/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = accounts.Get(id);

            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Balance")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    accounts.Update(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Account/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = accounts.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var account = accounts.Get(id);
            accounts.Remove(account);
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return accounts.Exists(id);
        }
    }
}

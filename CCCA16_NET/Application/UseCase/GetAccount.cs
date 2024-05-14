﻿using CCCA16_NET.Domain.Entity;
using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Application.UseCase
{
    public class GetAccount(IAccountRepository accountRepository)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task<Account> Execute(Guid accountId)
        {
            var account = await _accountRepository.GetAccountById(accountId);
            return account;
        }
    }
}

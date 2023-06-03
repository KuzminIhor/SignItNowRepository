using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SignItNow.Core;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Repositories
{
	public class DocumentInfoRepository: IDocumentInfoRepository
	{
		private DBAppContext db;

		private IEncryptorDecryptor encryptorDecryptor;

		public DocumentInfoRepository()
		{
			db = ServiceLocator.Get<DBAppContext>();

			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();
		}

		public DocumentInfo AddDocumentInfo()
		{
			Guid generatedGuid = GenerateNewGUID();

			while (db.DocumentInfos.FirstOrDefault(d => d.Name.Equals($"{generatedGuid.ToString()}.pdf")) != null)
			{
				generatedGuid = GenerateNewGUID();
			}

			db.DocumentInfos.Add(new DocumentInfo() {Name = $"{generatedGuid.ToString()}.pdf"});
			db.SaveChanges();

			return db.DocumentInfos.FirstOrDefault(d => d.Name.Equals($"{generatedGuid.ToString()}.pdf"));
		}

		public DocumentInfo GetDocumentInfo(int id)
		{
			var documentInfoInDB = db.DocumentInfos.FirstOrDefault(d => d.Id == id);

			return documentInfoInDB;
		}

		public DocumentInfo GetDocumentInfo(string name)
		{
			throw new NotImplementedException();
		}

		public void Remove(int id)
		{
			var documentInfoInDB = db.DocumentInfos.Include(d => d.TaskInfo).FirstOrDefault(d => d.Id == id);

			db.DocumentInfos.Remove(documentInfoInDB);
			db.SaveChanges();
		}

		private Guid GenerateNewGUID()
		{
			var guid = Guid.NewGuid();
			return guid;
		}
	}
}
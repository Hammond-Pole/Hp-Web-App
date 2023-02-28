﻿using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hp_Web_App.Shared.AppServices
{
    public interface IDocumentService
    {
        Task<Document> CreateDocument(Document document);
        Task<Document> GetDocument(int id);
        Task<List<Document>> GetDocuments();
        Task UpdateDocument(Document document);
    }

    public class DocumentService : IDocumentService
    {
        private readonly DbWebAppContext _context;

        public DocumentService(DbWebAppContext context)
        {
            _context = context;
        }

        public async Task<Document> CreateDocument(Document document)
        {
            _context.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }

        public async Task<Document> GetDocument(int id)
        {
            var document = new Document();

            document = await _context.FindAsync<Document>(id);

            return document;
        }

        public async Task<List<Document>> GetDocuments()
        {
            var documents = new List<Document>();

            documents = await _context.Set<Document>().ToListAsync();

            return documents;
        }

        public async Task UpdateDocument(Document document)
        {
            _context.Update(document);
            await _context.SaveChangesAsync();
        }
    }
}

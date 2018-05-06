using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LiteDB;
using SampleCoreArch.Core.Common;

namespace SampleCoreArch.Core.Interfaces
{
    public interface ILiteDbService<T>
    {
        //
        // Summary:
        //     Returns new instance of LiteQueryable that provides all method to query any entity
        //     inside collection. Use fluent API to apply filter/includes an than run any execute
        //     command, like ToList() or First()
        Result<LiteQueryable<T>> Query(string collectionName = null);

        //
        // Summary:
        //     Delete entity based on _id key
        Result<bool> Delete(BsonValue id, string collectionName = null);

        //
        // Summary:
        //     Delete entity based on Query
        Result<int> Delete(Query query, string collectionName = null);

        //
        // Summary:
        //     Delete entity based on predicate filter expression
        Result<int> Delete(Expression<Func<T, bool>> predicate, string collectionName = null);

        //void Dispose();
        //
        // Summary:
        //     Execute Query[T].Where(query).ToList();
        Result<List<T>> Fetch(Query query = null, string collectionName = null);

        //
        // Summary:
        //     Execute Query[T].Where(query).ToList();
        Result<List<T>> Fetch(Expression<Func<T, bool>> predicate, string collectionName = null);

        //
        // Summary:
        //     Execute Query[T].Where(query).First();
        Result<T> First(Query query = null, string collectionName = null);

        //
        // Summary:
        //     Execute Query[T].Where(query).First();
        Result<T> First(Expression<Func<T, bool>> predicate, string collectionName = null);

        //
        // Summary:
        //     Execute Query[T].Where(query).FirstOrDefault();
        Result<T> FirstOrDefault(Query query = null, string collectionName = null);

        //
        // Summary:
        //     Execute Query[T].Where(query).FirstOrDefault();
        Result<T> FirstOrDefault(Expression<Func<T, bool>> predicate, string collectionName = null);

        //
        // Summary:
        //     Insert a new document into collection. Document Id must be a new value in collection
        //     - Returns document Id
        Result<bool> Insert(T entity, string collectionName = null);

        //
        // Summary:
        //     Insert an array of new documents into collection. Document Id must be a new value
        //     in collection. Can be set buffer size to commit at each N documents
        Result<int> Insert(IEnumerable<T> entities, string collectionName = null);

        //
        // Summary:
        //     Execute Query[T].Where(query).Single();
        Result<T> Single(Expression<Func<T, bool>> predicate, string collectionName = null);

        //
        // Summary:
        //     Execute Query[T].Where(query).Single();
        Result<T> Single(Query query = null, string collectionName = null);

        //
        // Summary:
        //     Search for a single instance of T by Id. Shortcut from Query.SingleById
        Result<T> SingleById(BsonValue id, string collectionName = null);

        //
        // Summary:
        //     Execute Query[T].Where(query).SingleOrDefault();
        Result<T> SingleOrDefault(Query query = null, string collectionName = null);

        //
        // Summary:
        //     Execute Query[T].Where(query).SingleOrDefault();
        Result<T> SingleOrDefault(Expression<Func<T, bool>> predicate, string collectionName = null);

        //
        // Summary:
        //     Update a document into collection. Returns false if not found document in collection
        Result<bool> Update(T entity, string collectionName = null);

        //
        // Summary:
        //     Update all documents
        Result<int> Update(IEnumerable<T> entities, string collectionName = null);

        //
        // Summary:
        //     Insert or Update all documents based on _id key. Returns entity count that was
        //     inserted
        Result<int> Upsert(IEnumerable<T> entities, string collectionName = null);

        //
        // Summary:
        //     Insert or Update a document based on _id key. Returns true if insert entity or
        //     false if update entity
        Result<bool> Upsert(T entity, string collectionName = null);


        Result<List<T>> Paging(Expression<Func<T, bool>> filter = null, int skip = 1, int take = 5,
            string collectionName = null);

        Result<int> Count(Expression<Func<T, bool>> filter = null, string collectionName = null);
    }
}
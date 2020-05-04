# CrudCrm

Microsoft Dynamics CRM data uploading service

## Description

The database consists of several files that need to be imported to a CRM entity.
The update procedure may run regularly every day at night.

## Used approach

Late-bound classes

## Entity description

**Entity name:** acm_listinvaliddocument

**Primary key:** acm_listinvaliddocumentid (GUID)

## Entity attributes

| Attribute            | Attribute name       | Type        |
| ---------------------| -------------------- | ----------- |
| Document number      | acm_documentnumber   | string (10) |
| Series               | acm_batch            | string (4)  |
| Document type        | acm_documenttype     | picklist    |
| Date of invalidation | acm_invalidationdate | DateTime    |

## Document type

| Passport type | Number    |
| ------------- | --------- |
| WithoutSeries | 805210000 |
| WithSeries    | 805210001 |
| Violet        | 805210002 |
| Green         | 805210003 |

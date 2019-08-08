# ArticleApi
ArticleApi uygulaması; .Net Core Framework ile hazırlanmış bir makale apisidir.  Bu api üzerinden yapılan REST çağrıları ile; makale listeleme, arama, ekleme, güncelleme ve silme işlemleri gerçekleştirilir.

Projedenin veri tabanı işlemlerinde Repository design pattern'i kullanılmıştır. 
Bu pattern'i kullanmamdaki amaç; veri tabanı işlemlerinde ki kod tekrarlarının önüne geçerek kodların okunabilirliğini kolaylaştırmaktır. Ayrıca kodların test edilebilirliği ve oluşabilecek hataların yakalanabilirliği daha da kolaylaşacaktır.

ORM aracı olarak Entity Framework Core, mapping işlemleri için de; MVC ve WebForms projelerimde sıkça kullandığım AutoMapper tercih edilmiştir.

Projeye ilerleyen süreçlerde sayfalı listeleme ve kullanıcı yetkilendirme mekanizması dahil edilebilir. 

### Önemli: Projeyi çalıştırmadan önce appsettings.json içerisindeki ConnectionString'i kendi veri tabanınıza göre düzenlemeyi unutmayın.

Örnek veri tabanı tablolarını oluşturmak için gerekli script kodları:
```t-sql
create table dbo.Articles
(
	Id int identity,
	Title nvarchar(max),
	Content nvarchar(max),
	Author nvarchar(max),
	CreatedDate datetime2 not null,
	UpdatedDate datetime2 not null,
	constraint PK_Articles
		primary key (Id)
)
go

create table dbo.[__EFMigrationsHistory]
(
	MigrationId nvarchar(150) not null,
	ProductVersion nvarchar(32) not null,
	constraint PK___EFMigrationsHistory
		primary key (MigrationId)
)
go

INSERT INTO dbo.Articles (Id, Title, Content, Author, CreatedDate, UpdatedDate) VALUES (1, '.Net Core MVC Web Uygulamalarında Yetkilendirme – 1 (Scaffold Identity)', 'Bu yazıda; Microsoft’un bize hazır olarak sunduğu Scaffold Identity (Kimlik İskele) yapısından bahsedeceğim.  Böylelikle .Net Core Identity ara katmanına bir giriş yapmış olacağız, ve yapı hakkında bilgi sahibi olacağız.', 'Umur Onur', '2019-08-08 07:28:14.7987357', '2019-08-08 07:47:24.3544608');
INSERT INTO dbo.Articles (Id, Title, Content, Author, CreatedDate, UpdatedDate) VALUES (2, '.Net Core MVC Web Uygulamalarında Yetkilendirme – 2 (Custom Identity)', 'Önceki yazıda; Scaffold Identity yapısından bahsetmiştik. Scaffold Identity yapısı sayesinde, (Identity Middleware) kimlik ara katmanını projemize hızlı bir şekilde dahil edebilmekteyiz. Scaffold Identity hazır bir yapı olduğu için projemize varsayılan ayarlarıyla eklenmektedir. Bu kez; kendi sayfalarımızı oluşturup, Identity ara katmanını projemize göre nasıl düzenleyebiliriz bundan bahsedeceğiz.', 'Umut Onur', '2019-08-08 07:29:52.4112635', '2019-08-08 07:29:52.4112695');
INSERT INTO dbo.Articles (Id, Title, Content, Author, CreatedDate, UpdatedDate) VALUES (3, 'Blazor Üzerinde SignalR Core İle Zar Oyunu', 'Bugünkü örneğimizde, Blazor üzerinde .Net Core SignalR bir Hub sunucusuna bağlanıp, 2 client arasında zar oyunu oynayacağız. Bu 2 client, birbiri ile “one-to-one” haberleşeceklerdir. Kısacası bu makalede, ortaya yazılan “one-to-many” chat uygulaması yerine, connectionID’ye bağlı olarak, private bir haberleşme yapılacaktır.', 'Bora Kaşmer', '2019-08-08 07:31:39.8968813', '2019-08-08 07:31:39.8968852');
INSERT INTO dbo.Articles (Id, Title, Content, Author, CreatedDate, UpdatedDate) VALUES (4, 'Firebase Cloud Messaging ile Abonelere Bildirim Yollamak', 'Tarayıcı üzerinde yaşayan ve çevrim dışı ya da çok düşük internet hızlarında da çalışabilme özelliğine sahip olan PWA(Progressive Web Applications) uygulamalarının en önemli kabiliyetlerinden birisi de Push Notification''dır. Bu, mobil platformlardan yapılan erişimler düşünüldüğünde oldukça önemli bir nimettir. Arka planda içerik güncelleme (updating) özelliği de bir diğer önemli kabiliyettir. Bu yetenekler uygulama için tekrardan submit operasyonuna gerek kalmadan güncel kalabilmek anlamına da gelir.', 'Burak Selim Şenyurt', '2019-08-08 07:33:30.0177264', '2019-08-08 07:33:30.0177304');
go

INSERT INTO dbo.__EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20190807222311_DatabaseCreated', '2.2.6-servicing-10079');
go
```


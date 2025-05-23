# QRCode Management API

Bu proje, karekod (GS1 formatında) üretimi ve doğrulaması için geliştirilmiş bir .NET 8 Web API uygulamasıdır. Basit bir dış servis (ERP benzeri) entegrasyonu ve Swagger desteği ile birlikte gelir.

## Özellikler

- 12 haneli benzersiz GS1 uyumlu kod üretimi
- Kod doğrulama (`POST /validate`)
- Tüm kodları listeleme ve ID ile getirme
- MSSQL veritabanı ile kalıcı kayıt
- Swagger (OpenAPI) arayüzü
- xUnit ile basit birim testi
- Mock dış servis entegrasyonu (ERP simülasyonu)

## Teknolojiler

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (Code-First)
- xUnit
- Swagger / Swashbuckle
- HttpClient (Mock ERP entegrasyonu)

## Katmanlar

```text
QRCodeManagement.Domain          -> Entity tanımları (QRCode)
QRCodeManagement.Application     -> Servis arayüzleri (IQRCodeService, IErpService)
QRCodeManagement.Infrastructure  -> DbContext, servis implementasyonları
QRCodeManagement.API             -> Controller ve API uç noktaları
QRCodeManagement.Tests           -> Basit testler

## Görseller
![image](https://github.com/user-attachments/assets/e42c9904-6d9f-4846-8f46-492e062b6349)

![image](https://github.com/user-attachments/assets/4610f93f-afb8-4df9-b2d6-0b454270e593)

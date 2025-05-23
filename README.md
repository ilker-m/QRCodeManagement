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
  
## Resimler

![image](https://github.com/user-attachments/assets/e1671db3-f2ef-409e-ac80-82dc44aa3312)

![image](https://github.com/user-attachments/assets/877a867e-e4b8-49a4-beaa-de3b9f37d841)


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


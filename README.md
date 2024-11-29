# Contact:
- **Mail**: *lytranvinh.work@gmail.com*
- **Github**: *https://github.com/Youknow2509*

# Description
- Responsive save example:
    + Student: Ly Tran Vinh - 222631159
- This is [lab](https://drive.google.com/drive/folders/1OgKTA-QHvqH9YxsCD-gnzDaihNv7E45M)

# Một Số Lệnh Hay Dùng Trong Project:
- Tải dotnet ef global:
```shell
      dotnet tool install --global dotnet-ef
```

- Tạo Models từ database:
```shell
    dotnet ef dbcontext scaffold "Server=localhost,1435;Database=master;User Id=sa;Password=P@ss12345;TrustServerCertificate=true;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer -o Models --context-dir Data -c QuanLySinhVienDbContext --force
```

- Tạo Database từ Models:
```shell
    dotnet ef database update --context ApplicationDbContext
```

- Restore and Rebuild project:
```shell
    dotnet restore
    dotnet build
```

- Các package hay dùng:
```shell
    dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer 
    dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore 
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore 
    dotnet add package Microsoft.AspNetCore.Identity.UI 
    dotnet add package Microsoft.AspNetCore.WebUtilities 
    dotnet add package Microsoft.EntityFrameworkCore 
    dotnet add package Microsoft.EntityFrameworkCore.Design 
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer 
    dotnet add package Swashbuckle.AspNetCore 
    dotnet add package System.IdentityModel.Tokens.Jwt 
```

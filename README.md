## Novas Features do Projeto

Novo controller inserido: LoginController:

```code-font:
using Microsoft.AspNetCore.Mvc;
using PROJETOUNIP.Models;
using System.Diagnostics;

namespace PROJETOUNIP.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost("login")]
        public IActionResult Authenticate(string username, string password)
        {
            // Autenticação simplificada (apenas exemplo)
            if (username == "admin" && password == "password")
            {
                // Redireciona para uma página principal após o login bem-sucedido
                return RedirectToAction("Index", "Home");
            }

            // Em caso de falha, retorna à tela de login com uma mensagem de erro
            ViewBag.ErrorMessage = "Nome de usuário ou senha incorretos.";
            return View("Login");
        }
    }
}

```

## Novas Features do Projeto

Nova view inserida: LoginController:

```code-font:
@* Views/Login/Login.cshtml *@
@{
    Layout = null;
}

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login - Terra Verde</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
    <style>
        /* Estilos para a imagem de fundo */
        .background-image {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            object-fit: cover;
            z-index: -1; /* Fica atrás do formulário */
        }

        .login-container {
            position: relative;
            z-index: 10;
            max-width: 400px;
            width: 100%;
            background-color: rgba(255, 255, 255, 0.9);
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
        }
    </style>
</head>
<body class="d-flex align-items-center justify-content-center vh-100">

    <!-- Imagem de fundo -->
    <img src="~/—Pngtree—verdant natural green plant wall_13342238.jpg" alt="Background" class="background-image">

    <!-- Formulário de login -->
    <div class="login-container">
        <h2 class="text-center mb-4">Login</h2>
        <form asp-action="Authenticate" method="post">
            <div class="mb-3">
                <label for="username" class="form-label">Email</label>
                <input type="text" id="username" name="username" class="form-control" placeholder="Digite seu email" required />
            </div>

            <div class="mb-3">
                <label for="password" class="form-label">Senha</label>
                <input type="password" id="password" name="password" class="form-control" placeholder="Digite sua senha" required />
            </div>

            @* Exibe mensagem de erro, se houver *@
            @if (ViewBag.ErrorMessage != null)
            {
                <div class="alert alert-danger text-center" role="alert">
                    @ViewBag.ErrorMessage
                </div>
            }

            <button type="submit" class="btn btn-primary w-100">Entrar</button>
        </form>
    </div>

    <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>


```

no topo do Login.chtml em Views/Login, foi adicionado:

@{
Layout: null,
}

para remover como padrão o layout utilizado nas outras páginas, sendo assim, a barra de navegação só irá ser mostrada nas outras telas

## Reajuste em Program.cs

Agora, ao invés de exibir a pagina Home como padrão, será exibida a página de Login:

```code font:
 app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Login}/{action=Login}/{id?}");
```

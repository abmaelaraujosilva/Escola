public ActionResult EditarImagemAcai(int id)
{
    return View(new ImagemAcaiMapper().BuscarPorID(id));
}

[HttpPost]
// Observação 1 -- Na linha 8, tu coloca como parametro "HttpPostedFileBase Foto", mas tu me disse que queria salvar uma lista de imagens e para salvar uma lista tu tem que colocar como parametro "IEnumerable<HttpPostedFileBase> Fotos"
public ActionResult EditarImagemAcai(int id, ImagemAcai imagemAcai, HttpPostedFileBase Foto)
{

    if (ModelState.IsValid)
    {
        if (Foto != null)
        {
            // Observação 2 -- Me manda o codigo do metodo BuscarPorID(id) do Repositorio ImagemAcaiMapper
            imagemAcai.Foto = new ImagemAcaiMapper().BuscarPorID(id).Foto;

            string extensao = Foto.ContentType.ToString();
            extensao = extensao.Replace("image/", ".").ToLower();
            if (extensao == ".png" || extensao == ".jpg" || extensao == ".jpeg")
            {
                // Observação 3 -- Para que serve esse if na linha 23?, pois na linha 16 tu coloca alguma coisa dentro de "imagemAcai.Foto" sendo assim na linha 23 nunca deve ser null ou ""
                if (imagemAcai.Foto == null || imagemAcai.Foto == "")
                {
                    // Aqui é só uma dica, tu pode trocar o que ta na linha 26 pelo que eu coloquei na linha 27, acho que vai da certo
                    imagemAcai.Foto = "foto_acai_" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "") + extensao;
                    // imagemAcai.Foto = "foto_acai_" + DateTime.Now.ToBinary() + extensao;
                }
                else
                {
                    // deleta foto antiga
                    string camArquivo = System.IO.Path.Combine(Server.MapPath("~/Content/IMG/FotoAcai/"), imagemAcai.Foto);
                    if (System.IO.File.Exists(camArquivo))
                    {
                        System.IO.File.Delete(camArquivo);
                    }
                    // caso tenha mudado a extensão
                    imagemAcai.Foto = imagemAcai.Foto.Substring(0, imagemAcai.Foto.IndexOf(".")) + extensao;
                }
                // atualiza foto
                // Cara essa linha 42 não faz sentido para mim, porque que para montar o caminho que tu vai salvar a foto tu usa "imagemAcai.Foto"?, se tu quer atualizar a imagem tu não deveria usar a imagem que tu recebe como parametro que veio da View "HttpPostedFileBase Foto"? Pelo que eu entende aqui tu na linha 16 pega a imagem antiga e salva ela denovo na linha 42
                string caminhoArquivo = System.IO.Path.Combine(Server.MapPath("~/Content/IMG/FotoAcai/"), imagemAcai.Foto);
                // Na linha 44 é o mesmo problema da linha 42, pelo que eu vi tu não ta atualizando a imagem e sim ta salvando denovo a imagem antiga
                Foto.SaveAs(caminhoArquivo);
            }
            else
            {
                ViewBag.Erro = "Foto em formato inválido. A foto deve está em um dos seguintes formatos (png, jpg, jpeg).";
                // Nesse retorno da linha 50, tu realmente quer retorna o modelo "ImagemAcai" com a imagem que tu pegou do banco na linha 16 e retorna para a view, porque não sei se é a tua intenção mas o atributo "ImagemAcai.Foto" foi atualizado na linha 16, não é o mesmo que foi enviado pelo usuario
                return View(imagemAcai);
            }
        }

        imagemAcai.ID_Loja = GetID_Loja();
        // Cara eu vou te mandar um audio para falar da linha 56, porque é dificil só escrever o que eu quero dizer
        new ImagemAcaiMapper().Alterar(imagemAcai);
        return RedirectToAction("Index");
    }
    else
    {
        ViewBag.Erro = "Dados inválidos. Verifique o preenchimento dos campos e tente novamente.";
        return View(imagemAcai);
    }
}

[HttpPost]
public ActionResult EditarImagemAcai(int id, ImagemAcai imagemAcai, HttpPostedFileBase Foto)
{

    if (ModelState.IsValid)
    {
        if (Foto != null)
        {
            //imagemAcai.Foto = new ImagemAcaiMapper().BuscarPorID(id).Foto;

            string extensao = Foto.ContentType.ToString();

            extensao = extensao.Replace("image/", ".").ToLower();
            // Para que serve esse if na linha 80? pelo que eu entende ele verifica se a foto esta em alguma extenção conhecida, se sim, ele verifica na linha 84 se a foto que tu ta querendo salva ja existe na pasta onde tu salva as fotos e, se sim, deleta ela na linha 86, além disso ele coloca de novo a extenção dela na linha 89 caso, por algum motivo que eu não entende, ela tenha mudado sua extenção, então me diz: Porque ela mudaria sua extenção? e Como uma foto que tu salvou antes seria a mesma que tu ta trazendo se quando tu salva tu gera um numero aleatorio na linha 93 e adiciona esse numero no nome da imagem, e salva a imagem, tipo essa linha 93 não é pra garantir que uma foto que tu vai salvar nunca tenha o mesmo nome que uma que já esta la, sendo assim o que esta nas linha 84, 85, 86 e 87 não tem sentido existir, isso se meu raciocinio estiver certo, me diz ai o que tu acha
            if (extensao == ".png" || extensao == ".jpg" || extensao == ".jpeg")
            {
                // deleta foto antiga
                string camArquivo = System.IO.Path.Combine(Server.MapPath("~/Content/IMG/FotoAcai/"), imagemAcai.Foto);
                if (System.IO.File.Exists(camArquivo))
                {
                    System.IO.File.Delete(camArquivo);
                }
                // caso tenha mudado a extensão
                imagemAcai.Foto = imagemAcai.Foto.Substring(0, imagemAcai.Foto.IndexOf(".")) + extensao;
            }
            // atualiza foto
            // Me explica essa linha 93, porque pensa comigo, o atributo foto em "imagemAcai.Foto", traz o nome da foto direto da view certo? então quando chega na linha 93 tu quer apagar esse nome e substituir ele por "foto_acai_ + numeroAleatorio + extensao"? é realmente isso que tu quer fazer? alem disso se tu vai colocar a extenção da foto na linha 93, do que adianta a linha 89?, digo, lá tu coloca a extenção na linha 89 caso ela tenha mudado, mas aqui tu apaga o valor que está no atributo "imagemAcai.Foto" e coloca a extenção denovo?
            imagemAcai.Foto = "foto_acai_" + DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "") + extensao;
            // Na linha 95, levando em conta a linha 93, tu sempre salva um arquivo com nome nesse formato "foto_acai_ + numeroAleatorio + extensao" certo? é realmente isso que tu quer, digo, a unica diferença entre o nome vai ser esse numero, isso não muda muita coisa para a logica, ta de boa ser esse nome portanto que seja diferente, eu só quero saber se é realmente isso que tu quer
            string caminhoArquivo = System.IO.Path.Combine(Server.MapPath("~/Content/IMG/FotoAcai/"), imagemAcai.Foto);
            Foto.SaveAs(caminhoArquivo);
        }
        else
        {
            ViewBag.Erro = "Foto em formato inválido. A foto deve está em um dos seguintes formatos (png, jpg, jpeg).";
            return View(imagemAcai);
        }

        // Na linha 105 tu coloca dentro do atributo "imagemAcai.ID_Loja" o valor que o metodo "GetID_Loja()" traz, mas o ID_Loja não vem da View, porque tu muda ele aqui?
        imagemAcai.ID_Loja = GetID_Loja();
        new ImagemAcaiMapper().Alterar(imagemAcai);
        return RedirectToAction("Index");
    }
    return RedirectToAction("Index");
}
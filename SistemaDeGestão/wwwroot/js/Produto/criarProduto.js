


$(document).ready(function () {
    $('.selectpicker').selectpicker();
});
//Criar categoria
// Evento ao clicar no botão de salvar categoria
document.getElementById('salvarCategoriaBtn').addEventListener('click', function () {
    // Aqui você pode colocar o código para enviar os dados do formulário via AJAX
    var newCategoryName = document.getElementById('newCategoryName').value;
    var newCategoryDescription = document.getElementById('newCategoryDescription').value;

    if (newCategoryName && newCategoryDescription) {
        // Exemplo de requisição AJAX usando fetch
        fetch('/Categoria/PostNovaCategoria', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ Nome: newCategoryName, Descricao: newCategoryDescription })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Erro ao adicionar categoria: ' + response.statusText);
                }
                return response.json();
            })
            .then(data => {
                // Exemplo de uso do SweetAlert para exibir uma mensagem de sucesso
                Swal.fire({
                    icon: 'success',
                    title: 'Categoria adicionada com sucesso!',
                    showConfirmButton: false,
                    timer: 1500,
                });

                // Fechar o modal após adicionar a categoria
                $('#modalNovaCategoria').modal('hide');

                // Atualizar o dropdown de categorias usando SelectPicker
                fetch('/Categoria/FindAll')
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Erro ao obter categorias: ' + response.statusText);
                        }
                        return response.json();
                    })
                    .then(data => {
                        // Limpar o dropdown atual
                        var selectCategoria = document.getElementById('CategoriaId');
                        selectCategoria.innerHTML = '';

                        // Adicionar as novas opções ao dropdown
                        data.forEach(categoria => {
                            var option = document.createElement('option');
                            option.value = categoria.id;
                            option.textContent = categoria.nome;
                            selectCategoria.appendChild(option);
                        });
                        setTimeout(function () {
                            location.reload();
                        }, 1500);

                        // Atualizar o SelectPicker
                        $('.selectpicker').selectpicker('refresh');
                    })
                    .catch(error => {
                        console.error('Erro ao obter categorias:', error);
                    });
            })
            .catch(error => {
                console.error('Erro ao adicionar categoria:', error);
                Swal.fire({
                    icon: 'error',
                    title: 'Erro ao adicionar categoria',
                    text: 'Por favor, busque suporte do responsável especializado.'
                });
            });

    } else {
        alert('Por favor, preencha todos os campos.');
    }
});
//Gerenciar Categoria
function editarCategoria(categoriaId) {
    // Lógica para editar a categoria com o ID fornecido
    alert('Editar categoria: ' + categoriaId);
    // Aqui você pode abrir um modal de edição ou redirecionar para uma página de edição
}
function deletarCategoria(categoriaId) {
    if (confirm('Tem certeza de que deseja deletar esta categoria?')) {
        $.ajax({
            url: deleteCategoriaUrl,
            type: 'POST',
            data: { id: categoriaId },
            success: function (result) {
                if (result.success) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Categoria deletada com sucesso!',
                        showConfirmButton: false,
                        timer: 1500,
                    });
                    setTimeout(function () {
                        location.reload();
                    }, 1500);
                    // Remover a categoria da lista usando data-id
                    $('#categoria-list').find('li[data-id="' + categoriaId + '"]').remove();
                } else {
                    alert('Erro ao deletar a categoria.');
                }
            },
            error: function () {
                alert('Erro na comunicação com o servidor.');
            }
        });
    }
}

// Abrir modal para criar grupo de adicionais
document.getElementById('abrirModalGrupoAdicionalBtn').addEventListener('click', function () {
    $('#modalGrupoAdicional').modal('show');
});
// Criar grupo de adicionais
document.getElementById('formGrupoAdicional').addEventListener('submit', function (e) {
    e.preventDefault();

    var grupoNome = document.getElementById('grupoNome').value;

    if (grupoNome) {
        // Salvar o nome do grupo no localStorage ou em uma variável global
        localStorage.setItem('grupoNome', grupoNome);

        // Limpar o campo de nome do grupo
        document.getElementById('grupoNome').value = '';

        // Fechar modal de grupo de adicionais
        $('#modalGrupoAdicional').modal('hide');

        // Abrir modal de adicionais
        $('#modalAdicional').modal('show');
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Por favor, preencha o nome do grupo!',
            showConfirmButton: true
        });
    }
});
// Adicionar adicional ao grupo
document.getElementById('adicionarAdicionalBtn').addEventListener('click', function () {
    var adicionalNome = document.getElementById('adicionalNome').value;
    var adicionalPreco = document.getElementById('adicionalPreco').value;

    if (adicionalNome && adicionalPreco) {
        var adicionalItem = '<div>' + adicionalNome + ' - ' + adicionalPreco + '</div>';
        $('#adicionalList').append(adicionalItem);

        // Limpar campos de adicional
        document.getElementById('adicionalNome').value = '';
        document.getElementById('adicionalPreco').value = '';
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Por favor, preencha todos os campos!',
            showConfirmButton: true
        });
    }
});
// Salvar grupo de adicionais com seus adicionais
document.getElementById('salvarGrupoAdicionalBtn').addEventListener('click', function () {
    var grupoNome = localStorage.getItem('grupoNome');
    var adicionais = [];

    $('#adicionalList div').each(function () {
        var adicional = $(this).text().split(' - ');
        adicionais.push({
            Nome: adicional[0],
            Preco: parseFloat(adicional[1])
        });
    });

    if (grupoNome && adicionais.length > 0) {
        $.ajax({
            url: '@Url.Action("CriarGrupoAdicional", "GrupoAdicional")',
            type: 'POST',
            data: JSON.stringify({
                Nome: grupoNome,
                Adicionais: adicionais
            }),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                if (result.success) {
                    // Limpar campos
                    $('#formAdicional')[0].reset();
                    $('#adicionalList').empty();

                    // Fechar modal
                    $('#modalAdicional').modal('hide');

                    // Mostrar confirmação
                    Swal.fire({
                        icon: 'success',
                        title: 'Grupo de adicionais adicionado com sucesso!',
                        showConfirmButton: false,
                        timer: 1500
                    });

                } else {
                    Swal.fire({
                        icon: 'error',
                        title: result.message || 'Erro ao adicionar grupo de adicionais.',
                        showConfirmButton: true
                    });
                }
            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Erro na comunicação com o servidor.',
                    showConfirmButton: true
                });
            }
        });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Por favor, preencha todos os campos!',
            showConfirmButton: true
        });
    }
});
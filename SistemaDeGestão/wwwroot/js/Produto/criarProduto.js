
$(document).ready(function () {
    var adicionais = [];

    // Adicionar adicional ao grupo
    $('#adicionarAdicionalBtn').on('click', function () {
        var adicionalNome = $('#adicionalNome').val();
        var adicionalPreco = $('#adicionalPreco').val();

        if (adicionalNome && adicionalPreco) {
            var adicionalItem = '<div>' + adicionalNome + ' - ' + adicionalPreco + '</div>';
            $('#adicionalList').append(adicionalItem);

            // Limpar campos de adicional
            $('#adicionalNome').val('');
            $('#adicionalPreco').val('');
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Por favor, preencha todos os campos!',
                showConfirmButton: true
            });
        }
    });

    // Salvar grupo de adicionais com seus adicionais
    $('#salvarGrupoAdicionalBtn').on('click', function () {
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
                url: '/GrupoAdicional/CriarGrupoAdicional', // Substitua pela URL da sua API
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({
                    Nome: grupoNome,
                    Adicionais: adicionais
                }),
                success: function (response) {
                    // Sucesso no envio dos dados
                    console.log(response);

                    // Fechar o modal do grupo de adicionais
                    $('#modalGrupoAdicional').modal('hide');

                    // Resetar a lista de adicionais e o formulário do grupo
                    adicionais = [];
                    $('#formGrupoAdicional')[0].reset();
                    $('#adicionalList').empty();

                    Swal.fire({
                        icon: 'success',
                        title: 'Grupo de adicionais adicionado com sucesso!',
                        showConfirmButton: false,
                        timer: 1500
                    });
                    location.reload();
                },
                error: function (error) {
                    // Tratar erros
                    console.error(error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Erro ao salvar o grupo de adicionais.',
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

    $('#salvarETerminarBtn').on('click', function () {
        $('#modalGrupoAdicional').modal('show');
    });

    $('.selectpicker').selectpicker();
});

// Evento ao clicar no botão de salvar categoria
document.getElementById('salvarCategoriaBtn').addEventListener('click', function () {
    var newCategoryName = document.getElementById('newCategoryName').value;
    var newCategoryDescription = document.getElementById('newCategoryDescription').value;

    if (newCategoryName && newCategoryDescription) {
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
            Swal.fire({
                icon: 'success',
                title: 'Categoria adicionada com sucesso!',
                showConfirmButton: false,
                timer: 1500,
            });

            $('#modalNovaCategoria').modal('hide');

            fetch('/Categoria/FindAll')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Erro ao obter categorias: ' + response.statusText);
                }
                return response.json();
            })
            .then(data => {
                var selectCategoria = document.getElementById('CategoriaId');
                selectCategoria.innerHTML = '';

                data.forEach(categoria => {
                    var option = document.createElement('option');
                    option.value = categoria.id;
                    option.textContent = categoria.nome;
                    selectCategoria.appendChild(option);
                });
                setTimeout(function () {
                    location.reload();
                }, 1500);

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
    alert('Editar categoria: ' + categoriaId);
}

function deletarCategoria(categoriaId) {
    if (confirm('Tem certeza de que deseja deletar esta categoria?')) {
        console.log("arroz"); // Verifique se esta linha aparece no console
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

// Formulário de criação de grupo de adicionais
document.getElementById('formGrupoAdicional').addEventListener('submit', function (e) {
    e.preventDefault();

    var grupoNome = document.getElementById('grupoNome').value;

    if (grupoNome) {
        localStorage.setItem('grupoNome', grupoNome);

        document.getElementById('grupoNome').value = '';
        $('#modalGrupoAdicional').modal('hide');
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Por favor, preencha o nome do grupo!',
            showConfirmButton: true
        });
    }
});

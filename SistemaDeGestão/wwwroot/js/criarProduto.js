
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>


<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.13.18/js/bootstrap-select.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.13.18/js/i18n/defaults-pt_BR.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>
// Evento ao clicar no botão de salvar categoria
document.getElementById('salvarCategoriaBtn').addEventListener('click', function () {
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
                // Exemplo de uso do SweetAlert
                Swal.fire({
                    icon: 'success',
                    title: 'Categoria adicionada com sucesso!',
                    showConfirmButton: false,
                    timer: 1500
                });

                // Fechar o modal após adicionar a categoria
                $('#modalNovaCategoria').modal('hide');

                // Atualizar o dropdown de categorias
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
                    text: 'Busque suporte do responsável especializado'
                });
            });
    } else {
        alert('Por favor, preencha todos os campos.');
    }
});

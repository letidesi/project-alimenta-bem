using System.ComponentModel;

namespace alimenta_bem.src.natural.person.@enum;

public enum Gender
{
    [Description("Feminino")]
    Feminino,

    [Description("Masculino")]
    Masculino,

    [Description("Mulher Transgênero")]
    MulherTransgenero,
    [Description("Homem Transgênero")]
    HomemTransgenero,

    [Description("Pessoa Não-binária,")]
    PessoaNaoBinaria,

    [Description("Outros,")]
    Outros
}

public enum SkinColor
{
    [Description("Branca")]
    Branca,

    [Description("Preta")]
    Preta,

    [Description("Amarela")]
    Amarela,

    [Description("Parda")]
    Parda,

    [Description("Indígenas")]
    Indigenas
}
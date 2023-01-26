using Ardalis.SmartEnum;

namespace InterviewApp.Core.Enums;

public sealed class MovieGenreEnum : SmartEnum<MovieGenreEnum>
{
    public static readonly MovieGenreEnum Action = new(
        nameof(Action),
        1
    );
    public static readonly MovieGenreEnum Adventure = new(
        nameof(Adventure),
        2
    );
    public static readonly MovieGenreEnum Comedy = new(
        nameof(Comedy),
        3
    );
    public static readonly MovieGenreEnum Drama = new(
        nameof(Drama),
        4
    );
    public static readonly MovieGenreEnum Fantasy = new(
        nameof(Fantasy),
        5
    );
    public static readonly MovieGenreEnum Horror = new(
        nameof(Horror),
        6
    );
    public static readonly MovieGenreEnum Musical = new(
        nameof(Musical),
        7
    );
    public static readonly MovieGenreEnum Mystery = new(
        nameof(Mystery),
        8
    );
    public static readonly MovieGenreEnum Romance = new(
        nameof(Romance),
        9
    );
    public static readonly MovieGenreEnum ScienceFiction = new(
        nameof(ScienceFiction),
        10
    );
    public static readonly MovieGenreEnum Sports = new(
        nameof(Sports),
        11
    );
    public static readonly MovieGenreEnum Thriller = new(
        nameof(Thriller),
        12
    );
    public static readonly MovieGenreEnum Western = new(
        nameof(Western),
        13
    );

    private MovieGenreEnum(
        string name,
        int value
    ) : base(
        name,
        value
    ) { }
}
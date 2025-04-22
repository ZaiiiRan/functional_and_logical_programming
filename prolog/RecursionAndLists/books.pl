print_solution([]).
print_solution([person(Name, Prof, Book)|Rest]) :-
    write(Name), write(' is '), write(Prof), write(' and reads a book by '), write(Book), nl,
    print_solution(Rest).

solve :-
    People = [
        person(alekseev, ProfA, BookA),
        person(borisov, ProfB, BookB),
        person(konstantinov, ProfK, BookK),
        person(dmitriev, ProfD, BookD)
    ],
    
    Professions = [astronomer, poet, prose_writer, playwright],
    permutation([ProfA, ProfB, ProfK, ProfD], Professions),
    
    % Уникальные книги (по авторам)
    Books = [alekseev, borisov, konstantinov, dmitriev],
    permutation([BookA, BookB, BookK, BookD], Books),
    
    % Никто не читает свою книгу
    BookA \= alekseev,
    BookB \= borisov,
    BookK \= konstantinov,
    BookD \= dmitriev,
    
    % Борисов читает книгу Дмитриева
    BookB = dmitriev,
    
    % Поэт читает пьесу (книгу драматурга)
    member(person(_, poet, BookPoet), People),
    member(person(PlaywrightName, playwright, _), People),
    BookPoet = PlaywrightName,
    
    % Прозаик не читает книгу астронома
    member(person(_, prose_writer, BookProse), People),
    member(person(AstronomerName, astronomer, _), People),
    BookProse \= AstronomerName,
    
    print_solution(People),
    !.
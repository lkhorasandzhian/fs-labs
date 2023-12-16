% Хорасанджян Левон. Вариант 8.

% Структура: person(name, job, chess_rate, ski_rate, theatre_rate, age_rate).
% Всё, что помечено постфиксом '_rate' означает степень мастерства, т. е. 1 - худший, а 4 - лучший.
% В случае с 'age_rate' — 1 - самый молодой, 4 - самый старый.
engineers(L) :-
    L = [
        person(borisov, _, _, _, _, _),
        person(kirillov, _, _, _, _, _),
        person(danin, _, _, _, _, _),
        person(savin, _, _, _, _, _)
    ],
    member(person(borisov, _, _, _, _, _), L),
    member(person(kirillov, _, _, _, _, _), L),
    member(person(danin, _, _, _, _, _), L),
    member(person(savin, _, _, _, _, _), L),
    member(person(_, automechanic, _, _, _, _), L),
    member(person(_, chemist, _, _, _, _), L),
    member(person(_, builder, _, _, _, _), L),
    member(person(_, radiotechnician, _, _, _, _), L),

    member(person(borisov, builder, _, _, _, _), L),
    member(person(kirillov, automechanic, _, _, _, _), L),
    member(person(danin, chemist, _, _, _, _), L),
    member(person(savin, radiotechnician, _, _, _, _), L),

    member(person(_, _, 1, _, _, _), L),
    member(person(_, _, 2, _, _, _), L),
    member(person(_, _, 3, _, _, _), L),
    member(person(_, _, 4, _, _, _), L),
    member(person(_, _, _, 1, _, _), L),
    member(person(_, _, _, 2, _, _), L),
    member(person(_, _, _, 3, _, _), L),
    member(person(_, _, _, 4, _, _), L),
    member(person(_, _, _, _, 1, _), L),
    member(person(_, _, _, _, 2, _), L),
    member(person(_, _, _, _, 3, _), L),
    member(person(_, _, _, _, 4, _), L),
    member(person(_, _, _, _, _, 1), L),
    member(person(_, _, _, _, _, 2), L),
    member(person(_, _, _, _, _, 3), L),
    member(person(_, _, _, _, _, 4), L),
    
    % 1. Из условия "Борисов, который обыгрывает в шахматы Данина, но проигрывает Савину"
    % следует, что Борисов не самый слабый и не самый сильный шахматист,
    % при этом Данин не самый сильный шахматист, а Савин не самый слабый.
    \+ member(person(borisov, _, 1, _, _, _), L),
    \+ member(person(borisov, _, 4, _, _, _), L),
    \+ member(person(danin, _, 4, _, _, _), L),
    \+ member(person(savin, _, 1, _, _, _), L),

    % 2. Из условия "Борисов бегает на лыжах лучше того инженера, который моложе его"
    % следует, что Борисов не самый слабый лыжник и не самый молодой инженер.
    \+ member(person(borisov, _, _, 1, _, _), L),
    \+ member(person(borisov, _, _, _, _, 1), L),

    % 3. Из условия "Борисов ходит в театр чаще, чем тот инженер, который старше Кириллова"
    % следует, что Борисов не самый слабый театрал, а Кириллов не самый старый инженер.
    \+ member(person(borisov, _, _, _, 1, _), L),
    \+ member(person(kirillov, _, _, _, _, 4), L),

    % 4. Из условия "Химик, который посещает театр чаще, чем автомеханик, но реже, чем строитель"
    % следует, что химик не самый слабый и не самый сильный театрал,
    % при этом автомеханик не самый сильный театрал, а строитель не самый слабый.
    \+ member(person(_, chemist, _, _, 1, _), L),
    \+ member(person(_, chemist, _, _, 4, _), L),
    \+ member(person(_, automechanic, _, _, 4, _), L),
    \+ member(person(_, builder, _, _, 1, _), L),

    % 5. Из условия "Химик не является ни самым молодым, ни самым старшим из этой четверки"
    % следует то, что сказано :).
    \+ member(person(_, chemist, _, _, _, 1), L),
    \+ member(person(_, chemist, _, _, _, 4), L),

    % 6. Из условия "Строитель, который на лыжах бегает хуже, чем радиотехник"
    % следует, что строитель не самый сильный лыжник, а радиотехник не самый худший.
    \+ member(person(_, builder, _, 4, _, _), L),
    \+ member(person(_, radiotechnician, _, 1, _, _), L),

    % 7. Из условия "Строитель, как правило, проигрывает в шахматных сражениях автомеханику"
    % следует, что строитель не самый сильный шахматист, а автомеханик не самый слабый.
    \+ member(person(_, builder, 4, _, _, _), L),
    \+ member(person(_, automechanic, 1, _, _, _), L),

    % 8. Из условия "Самый пожилой из инженеров лучше всех играет в шахматы и чаще всех бывает в театре"
    % следует, то, что сказано :).
    member(person(_, _, 4, _, _, 4), L),
    member(person(_, _, _, _, 4, 4), L),

    % 9. Из условия "самый молодой лучше всех ходит на лыжах"
    % следует, то, что сказано :).
    member(person(_, _, _, 4, _, 1), L).

extract_names_jobs([], []).
extract_names_jobs([person(Name, Job, _, _, _, _) | Rest], [Name - Job | NamesJobsRest]) :-
    extract_names_jobs(Rest, NamesJobsRest).

solution(NamesJobs) :-
    engineers(Engineers),
    extract_names_jobs(Engineers, NamesJobs).

unique_solution(L) :-
    setof(Solution, solution(Solution), L).

"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ChessGameService = /** @class */ (function () {
    function ChessGameService(httpClient) {
        this.httpClient = httpClient;
        this.games = [
            {
                white: "Gary Kasparov",
                black: "Nigel Short",
                result: "1/2-1/2",
                event: "An event",
                round: "1",
                site: "Somewhere over the rainbow",
                date: "??.??.??",
                moves: "1. e4 e5 2. Nf3 Nc6 3. Bb5 a6 4. Ba4 Nf6 5. O - O Be7 6. Re1 b5 7. Bb3 d6 8. c3 O- O 9. h3 Nb8 10. d4 Nbd711. c4 c6 12. cxb5 axb5 13. Nc3 Bb7 14. Bg5 b4 15. Nb1 h6 16. Bh4 c5 17. dxe5Nxe4 18. Bxe7 Qxe7 19. exd6 Qf6 20. Nbd2 Nxd6 21. Nc4 Nxc4 22. Bxc4 Nb623. Ne5 Rae8 24. Bxf7 + Rxf7 25. Nxf7 Rxe1 + 26. Qxe1 Kxf7 27. Qe3 Qg5 28. Qxg5hxg5 29. b3 Ke6 30. a3 Kd6 31. axb4 cxb4 32. Ra5 Nd5 33. f3 Bc8 34. Kf2 Bf535. Ra7 g6 36. Ra6 + Kc5 37. Ke1 Nf4 38. g3 Nxh3 39. Kd2 Kb5 40. Rd6 Kc5 41. Ra6Nf2 42. g4 Bd3 43. Re6"
            },
            {
                white: "Gary Kasparov",
                black: "Nigel Short",
                result: "1/2-1/2",
                event: "An event",
                round: "1",
                site: "Somewhere over the rainbow",
                date: "??.??.??",
                moves: "1. e4 e5 2. Nf3 Nc6 3. Bb5 a6 4. Ba4 Nf6 5. O - O Be7 6. Re1 b5 7. Bb3 d6 8. c3 O- O 9. h3 Nb8 10. d4 Nbd711. c4 c6 12. cxb5 axb5 13. Nc3 Bb7 14. Bg5 b4 15. Nb1 h6 16. Bh4 c5 17. dxe5Nxe4 18. Bxe7 Qxe7 19. exd6 Qf6 20. Nbd2 Nxd6 21. Nc4 Nxc4 22. Bxc4 Nb623. Ne5 Rae8 24. Bxf7 + Rxf7 25. Nxf7 Rxe1 + 26. Qxe1 Kxf7 27. Qe3 Qg5 28. Qxg5hxg5 29. b3 Ke6 30. a3 Kd6 31. axb4 cxb4 32. Ra5 Nd5 33. f3 Bc8 34. Kf2 Bf535. Ra7 g6 36. Ra6 + Kc5 37. Ke1 Nf4 38. g3 Nxh3 39. Kd2 Kb5 40. Rd6 Kc5 41. Ra6Nf2 42. g4 Bd3 43. Re6"
            },
            {
                white: "Gary Kasparov",
                black: "Nigel Short",
                result: "1/2-1/2",
                event: "An event",
                round: "1",
                site: "Somewhere over the rainbow",
                date: "??.??.??",
                moves: "1. e4 e5 2. Nf3 Nc6 3. Bb5 a6 4. Ba4 Nf6 5. O - O Be7 6. Re1 b5 7. Bb3 d6 8. c3 O- O 9. h3 Nb8 10. d4 Nbd711. c4 c6 12. cxb5 axb5 13. Nc3 Bb7 14. Bg5 b4 15. Nb1 h6 16. Bh4 c5 17. dxe5Nxe4 18. Bxe7 Qxe7 19. exd6 Qf6 20. Nbd2 Nxd6 21. Nc4 Nxc4 22. Bxc4 Nb623. Ne5 Rae8 24. Bxf7 + Rxf7 25. Nxf7 Rxe1 + 26. Qxe1 Kxf7 27. Qe3 Qg5 28. Qxg5hxg5 29. b3 Ke6 30. a3 Kd6 31. axb4 cxb4 32. Ra5 Nd5 33. f3 Bc8 34. Kf2 Bf535. Ra7 g6 36. Ra6 + Kc5 37. Ke1 Nf4 38. g3 Nxh3 39. Kd2 Kb5 40. Rd6 Kc5 41. Ra6Nf2 42. g4 Bd3 43. Re6"
            },
            {
                white: "Gary Kasparov",
                black: "Nigel Short",
                result: "1/2-1/2",
                event: "An event",
                round: "1",
                site: "Somewhere over the rainbow",
                date: "??.??.??",
                moves: "1. e4 e5 2. Nf3 Nc6 3. Bb5 a6 4. Ba4 Nf6 5. O - O Be7 6. Re1 b5 7. Bb3 d6 8. c3 O- O 9. h3 Nb8 10. d4 Nbd711. c4 c6 12. cxb5 axb5 13. Nc3 Bb7 14. Bg5 b4 15. Nb1 h6 16. Bh4 c5 17. dxe5Nxe4 18. Bxe7 Qxe7 19. exd6 Qf6 20. Nbd2 Nxd6 21. Nc4 Nxc4 22. Bxc4 Nb623. Ne5 Rae8 24. Bxf7 + Rxf7 25. Nxf7 Rxe1 + 26. Qxe1 Kxf7 27. Qe3 Qg5 28. Qxg5hxg5 29. b3 Ke6 30. a3 Kd6 31. axb4 cxb4 32. Ra5 Nd5 33. f3 Bc8 34. Kf2 Bf535. Ra7 g6 36. Ra6 + Kc5 37. Ke1 Nf4 38. g3 Nxh3 39. Kd2 Kb5 40. Rd6 Kc5 41. Ra6Nf2 42. g4 Bd3 43. Re6"
            },
            {
                white: "Gary Kasparov",
                black: "Nigel Short",
                result: "0-1",
                event: "An event",
                round: "1",
                site: "Somewhere over the rainbow",
                date: "??.??.??",
                moves: "1. e4 e5 2. Nf3 Nc6 3. Bb5 a6 4. Ba4 Nf6 5. O - O Be7 6. Re1 b5 7. Bb3 d6 8. c3 O- O 9. h3 Nb8 10. d4 Nbd7 11. c4 c6 12. cxb5 axb5 13. Nc3 Bb7 14. Bg5 b4 15. Nb1 h6 16. Bh4 c5 17. dxe5Nxe4 18. Bxe7 Qxe7 19. exd6 Qf6 20. Nbd2 Nxd6 21. Nc4 Nxc4 22. Bxc4 Nb623. Ne5 Rae8 24. Bxf7 + Rxf7 25. Nxf7 Rxe1 + 26. Qxe1 Kxf7 27. Qe3 Qg5 28. Qxg5hxg5 29. b3 Ke6 30. a3 Kd6 31. axb4 cxb4 32. Ra5 Nd5 33. f3 Bc8 34. Kf2 Bf535. Ra7 g6 36. Ra6 + Kc5 37. Ke1 Nf4 38. g3 Nxh3 39. Kd2 Kb5 40. Rd6 Kc5 41. Ra6Nf2 42. g4 Bd3 43. Re6"
            },
            {
                white: "Gary Kasparov",
                black: "Nigel Short",
                result: "1-0",
                event: "An event",
                round: "1",
                site: "Somewhere over the rainbow",
                date: "??.??.??",
                moves: "1. e4 e5 2. Nf3 Nc6 3. Bb5 a6 4. Ba4 Nf6 5. O - O Be7 6. Re1 b5 7. Bb3 d6 8. c3 O- O 9. h3 Nb8 10. d4 Nbd7 11. c4 c6 12. cxb5 axb5 13. Nc3 Bb7 14. Bg5 b4 15. Nb1 h6 16. Bh4 c5 17. dxe5Nxe4 18. Bxe7 Qxe7 19. exd6 Qf6 20. Nbd2 Nxd6 21. Nc4 Nxc4 22. Bxc4 Nb623. Ne5 Rae8 24. Bxf7 + Rxf7 25. Nxf7 Rxe1 + 26. Qxe1 Kxf7 27. Qe3 Qg5 28. Qxg5hxg5 29. b3 Ke6 30. a3 Kd6 31. axb4 cxb4 32. Ra5 Nd5 33. f3 Bc8 34. Kf2 Bf535. Ra7 g6 36. Ra6 + Kc5 37. Ke1 Nf4 38. g3 Nxh3 39. Kd2 Kb5 40. Rd6 Kc5 41. Ra6Nf2 42. g4 Bd3 43. Re6"
            }
        ];
    }
    return ChessGameService;
}());
exports.ChessGameService = ChessGameService;
//# sourceMappingURL=ChessGameService.js.map
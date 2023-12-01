using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2022
{
    public class InputData
    {
        #region Day0
        public const string Day0 = @"";
        #endregion
        #region Day1a
        public const string Day1a = @"7896
4992
1382
2920
7533
2709
6020
5321
2698
6806
8008

1340
1472
7147
2707
5491
7003
2337
1401
5309
4385
2805

6019
1924
8917
6303
9358
3640
1563
1902

10946
10333
8504
6110
10157

4578
1711
3343
6159
4045
3487
3070
5663
3518
5839
5911
4970
4852
4512

4277
3324
6172
8272
2707
3292
6599
1204
7030
3075

6907
5595
10251
8654
4036
11545

16787
11035
12217

2196
1519
5810
6837
1193
6480
1237
1659
4323
2896
3878
2894

15886
20356
23636

8795
7986
14228
15738
13503

6598
17951
17508
2446

1382
3232
6467
2791
6250
2704
3898
5569
8676

2582
8767
3195
7957
6614

24737
34912

28868
34308

2703
20947

5548
5930
6705
4227
6120
8723
4597

5877
1223
5789
2207
3488
5210
3056
4300
3880
1826
5366
4531
2016
5304

4226
5314
6437
1737
1229
3757
5128
1058
5940
3344
5188
4963
1403
5498

4969
3096
7035
2695
4747
5109
6294
7990
1539
2608
2944

14127
9751
4842
1106
2779

11896
6643
15874
10487
4141

4696
6644
6285
4321
4080
6888
5213
5048
6545
5848
1690
5351
2560

17296
4277
8327
7931

8374
3794
5435
6968
4768
3458

5090
5614
9448
10331
1311
12604

5126
4860
1299
6934
11746
2628
12132

6648
8567
10219
2385
3642
10478
7662

9206
2176
6472
12314

7006
9478
2742
12074
11993
3221

2458
4271
6417
13749
5411

7826
4566
10845
4535
5673
8305

8264
11302
7040
9481
9935
6624
8376

10460
20936

3456
3498
6808
7408
5543
3673
6672
6650
7560
2477
6505

6943
3217
6235
5079
1386
3453
1736
4569
1422
2804
5807

2241
1925
3348
4805
2575
3656
1379
5628
2348
4652
5052
5788
4128
2160

4839
3854
3192
4055
1892
5418
6415
1645
1609
3844
3097
2117
4043

6996
16021
23549

5493
5824
7101
5017
8221
5407
1963
6083

4896
18916
17584
19464

2897
1198
1847
4416
3086
2006
1743
1387
3390
1416
4713
3831
2789
5146
2220

9452
8265
6453
2831
3803
1928
1047
5087
9454

2885
1518
5218
2629
5204
3715
4468
4399
3020
5194
5361
4566
5875
3995
3081

5435
3159
1378
1333
4491
5405
4858
3744
5468
2313
3014
2236

7027
5112
6675
1149
5519
7197
5210
3811
1259
3794
2700
6518

6066
2040
1948
2972
3816
1477
4477
3085
4169
1245
5008
2016
4449
1544
1511

5909
3378
12050
6988
11093
8034
2552

5647
7225
1416
4531
2148
5176
1086
1268
3907

8824
12672
6094
4105

9982
1255
5102
2060
8348
8610
9019

6442
8353
2849
6823
5061
8540

1020
4819
2371
6452
2589
2140
3018
6422
2079
1049
4183
1959
6889

3370
20341
6283

3568
8914
2474
1840
1092
2901
4619

5489
5048
2151
1275
4555
6105
6393
5439
1175
3143
1039
6159
4280

25302
11104

16342
19486
6818
5872

4287
7300
5106
6009
5397
4743
8786
5374
7723
3342

7830
4687
3639
5942
8019
7531
4763
8086

2928
12662
1729
15599
7031

4504
8351
3310
2860
7474
1052
7088
7300
7653

3800
3285
2244
6146
1527
2496
3373
2935
4073
2708
5854
4532
4265

38782

3895
2886
3397
10665
7954
5994

3830
4381
4042
3631
2109
2742
2748
1117
2772
1921
4357
2960
4504
6021
2300

5684
30508

5467
4827
7991
4299
4152
7070
1911
1345
5607
6490
5631

2288
4534
1402
2221
2137
4623
5745
1848
1638
2562
1095
2539
4090
3929
4330

3776
11693
1189
2039
2662
11224
9212

3778
1619
4008
1706
1926
3844
5194
3554
6272
2988
4779
5481
1443
6297

1712
6076
7332
5267
6685
2555
4517
8692
1819

23640
10894
25482

10592
9277
1228
1197
9162
4838
3783
2691

15579
16090
5228
4273
5288

4044
10911
4767
8658
5775
9369
5332

8063
4322
5109
6744
5653
9544
2610
2241

3885
1140
10508
11910
6096

7234
15371
10892
15338
12191

3698
3413
3783
3362
1828
1302
3426
3147
5558
2644
3636
5842
5261
3312
3164

3088
1303
2194
5841
5330
5986
4108
4571
7161
6276
5920
5011

6546
30555

5922
2401
4792
7175
7942
5040
3601
2213
6802
2244
6891

2694
7905
6046
3782
5591
3665
4195
4579
4300
1822

6308
2993
5663
4780
6638
6503
6307
4682
7281
4580
7441
5611

9706
4619
2108
8345
2422
12140
9146

4984
10121
4062
3797
5130
1641
11492

7592
9412
5474
7809
8073
2056
3839
3557

7893
3556
9427
2836
10256

4410
3041
2124
5830
4200
4102
5146
3355
4318
5422
4992
1979
2696
5277
4058

13134
35366

5363
1706
4925
5967
8514
3362
1424
4427
8906

2891
4388
10112
3409
2477
1138
3790
4712

9130
4622
9723
4660
2778
1083
2326
9254

3221
4739
3752
1220
10337
1159
2367
1900

2038
5545
5904
5378
4334
2897
5745
3670
4773
3087
5760
4026
3719
3084

8674
8656
4162
5125
4183
3496
7379
6150
5225
8014

10321
16081
6163
2030

31755
18352

1666
15493
8858
15689

1903
7006
9002
5067
9397
8703
7534
8188
4983

4398
12055
6820
2412
10308
11231

5914
9582
4568
7679
5867
5798
2955
7834
1833

2554
1886
4590
3753
3161
4039
2435
1172
2690
4564
5160
3715
2834
6074
1251

9837
4501
3669
7682
2762
6072
8731
2324

7030
6956
3040
2185
4717
2907
5255
1194
1309
5100
5630
5164

18808
5780
13062
16131

5436
13758
12390
14884

5344
3178
1907
6945
6435
3985
3637
6984
2108
2282

6870
3774
4149
3361
3208
3696
4265
2295
7068
4365
6729

9828
3819
7654
2391
11354
6751

5409
6025
6772
4005
6894
2723
2485
5866
5744
1804
2509
3285
5663

6630
7966
6366
2854
3478
6566
3790
4047
8471
5911

5930
4813
10365
1430

13119
11915
4732
9949
13699
9790

3413
3027
5513
3320
4421
2507
5781
2622
5472
6590
2021
2164
4106

49386

3656
7422
6157
5982
3944
5726
2628
6618
6138
2186
4744

33805

9976
4213
4359
3723

4106
1423
3334
5115
3819
1308
2652
5954
4439
2188
3415
1104
2973
1681
4704

64085

1097
4369
3803
3247
5135
6928
3419
2418
5130
2555
3043

4831
2425
2023
1667
6410
6422
5851
4966
6721
5312
3792
6700
1545

1742
5176
8587
9261
15254

3097
6016
5558
3004
4372
1986
5576
6105
1709
1326
4997
5528
2823
3072

1228
2891
3056
5874
2267
2232
1754
3979
1881
6633
1889
5506
4377

3703
6310
1020
4891
4911
2913
3888
4642
1963
3716
2222
4528
1030
6081

10172
1472
6212
9125
9365
7866
3525
4752

2546
2326
5739
1010
4724
5324
2495
2999
5272
1937
4396
6333
3632

2944
1285
3457
1980
2346
5712
5088
3718
2036
6725

4335
5577
4533
3275
4297
2774
5029

1396
5993
4058
1095
4388
1843
1643
6192
2801
2583
4286
5483
2308
1577

1584
7552
8133
9503
1989

4584
7691
4707
5757
2519
2097
1460
6651
3569
1159

9366
3998
2020
2598
2166
3298
6533
1323

10007
2282
10952
3217
8819
7164

3095
1126
1893
1540
3172
2310
2566
2438
4431
3423
6675

4131
9513
11678
5248
7769
3887
3494

5382
1013
4021
7366
12330
13746

3536
4407
1205
6210
1388
6202
5314
3286
6888
3049
3946
3684
4187

1934
1285
3262
4136
5790
1340
2597
2992
3008
5698
3688
3086
2459
2413
4769

2150
1030
3068
3747
5417
4237
3311
5081
4846
5555
4650
3830
2209
3069

9935
9564
15110

3038
2079
1059
4905
4104
3502
6338
1366
5990
6073
4692
4706
3474
3469

5845
1176
5553
4578
3868
6154
4799
5079
5927
4185
1806
4449
6248

1280
2823
1372
5899
2547
5738
1545
1046
2917
4931
6094
3690
5021
4657
1214

3046
4952
1138
2373
1412
4848
5772
4750
4741
5752
5977
5270
5526
3509
1793

3228
9849
11815
6507
10144
4756

5119
1764
1718
4813
3662
4731
2755
1315
1975
5716
4859
4748
4809
1296
1689

2909
7209
6124
3235
4089
1271
6220
10328

5630
10237
5572
1065
2126
7181

32487
2379

2718
4228
7834
6711
7619
6321
1080
8584
6860
6542

5106
8514
6109
1204
5159
7935
7292
8114

5898
4837
6825
4587
1021
5713
4862
3864
2022
1129
4444
6439
4369

8875
7916
2177
2085
8103
7908
6266
9099

23274
30650

5537
21092
21841

5852
9025
4459
4883
2577
4679
5673
1548
6726

4034
2542
15179
6499
3472

2228
5558
7863
5080
6441
2064
1676
8473

18854
5610
18471

1196
3063
13221
19006

37369
24756

4271
6806
6381
6363
5221
5729
3829
7832
1150
3352
3210

1422
2606
6070
4950
4300
4023
1862
5027
5668
5058
3969
2359
5394
6001

12165
13318
11945
12507
11398

9539
8607
7451
11189
11056
3209

5845
2759
4046
3838
2768
1168
1237
6370
3384
3938
3946
5028
2603

20671
8067
7232

7376
3530
3343
4917
6712
5080
5846
2774
3020
5738
5500

5185
2455
6887
7349
1917
2435
2458
3676
1783
8567

5585
3750
2664
6867
1506
6830
1279
7877
2757
4091
2731

11132

6128
2421
5519
4390
6457
2769
1410
3365
5682
5685
1502
3245

1265
7559
8923
1805
9738
3780
9131

3052
5440
1672
3462
1053
2902
2137
5053
4905
3544
4374
2718
5799

24868
18500
13495

4653
5142
2117
2908
2324
4335
1096
6733
2380
5352
1830
1893
2491

3142
4111
4577
6019
1075
2596
4950
5814
5880
5573
3672
2623
5602
1032
5599

7365
2959
6303
6111
4607
6530
4873
4367
3776

16700
7439
4758
6160

4203
1817
2941
5662
1387
1698
3031
3718
6087
4971
5592
4460
5271
3867
4998

22671
4704
23657

5028
5059
4212
1200
2284
6082
4589
4383
4682
1243
6449
1380
4515

10431
11132
13078
3070
8963
1329

3931
6924
5760
2448
4709
13742

4493
4759
5130
5004
7898
8508
6718
2769
5103
4254

2261
4383
1602
3767
4634
3704
4242
6316
5351
3531
3470
3904

3541
2879
1596
4477
1209
2089
4365
4813
1830
1069
2994
6076
3379
4130
4102

11774
16285
15432

1364
3558
5162
4115
2730
3464
2673
4541
5020
5299
3199
3221
4372

2696
2080
4206
1901
6091
4955
2674
2184
4977
4339
1011
3766
5911
5316
3703

21030

6714
3093
1168
1507
5134
6516
1572
8383

5080
7055
6559
4514
7036
7348
5836
2223
1996
4888
3666

25117
18822

2855
4165
4812
8068
6471
4447
4482
4775
1002

5999
5674
4022
7403
5593
6164
5109
6856
3449
1689
3727
2115

5781
4639
3684
4010
4018
1004
3081
1003
1702
1457
1301
2122
2014
5790

6373
1849
4389
5772
4888
7981
4238
1476
5550
2922

1513
8603
5489
6664
4505
7378
4185
8087
6799

6482
3622
5516
6214
6243
6214
4711
3038
3398
5483
3145
3536

9125
5549
8576
5240
6032
7952
5140
7580

6079
2048
4407
5706
2535
4588
5182
3204
5287
5221
2457
6932
4174

5505
1576
13849
5436
2535
3865

2178
5420
1013
6435
3810
2903
5079
4332
6257
1344
4511
3127
6464

3805
2215
1614
2501
1067
1874
6199
1733
2146
6581
3514
1175
1099

6473
3376
4934
5773
4970
7229
5716
1014
7507
6012

3636
3377
5729
2413
6252
3314
2928
2317
1157
2788
3842
3906
4650
5338

5103
2724
3794
1431
5838
3971
2107
6475
1746
5986
3736
6345
4124
5664

3774
2420
1478
2100
2608
1168
1584
1266
1346
1262
6217
6392
2148
4525

3294
14112
2438
13482
4287

10170
4078
4238
3724
8472
9110
5386
3743

10397
11155
4476
7990
8374
3340
4575

27723

7777
9699
8470
1721
7728
1288
4458
3428

12000
5191
8549
9184
3081
11587
9430

13626
2596
12534
7672
5161
1160

7830
3505
7940
4756
6977
3085
2639
6439
4919
1421
5196

2714
1424
7020
8593
1436
7652
1146
4168
2069
5958

38215

1436
6327
10725
4280
4509
10301
5183
5166

6068
8243
6171
5575
9093
6123
2831
5664
6278

4093
4619
2578
5902
1131
3288
4886
4994
6088
6377
1852
4254
1419
1504

7127
8649
2523
8023
3063
2677
1759
8632
7805
2999

3419
1111
5599
1055
3407
4964
3556
7249
1100
7148
1852
1549

5414
11474
1685
8818
10288
6138
1983

23129
2195

3104
1599
2327
3640
2230
2791
2344
1035
1046
3399
5096
1067
1987
5786
1395

32647
10609

6020
2279
8718
3103
7022
6464
6180
3968
3275

3221
5381
6110
1860
4557
4705
3658
4172
5002
5578
1355
4114
3501
4821

1312
1921
2644
5044
3336
4520
1253
3184
3732
6754
2139";
        #endregion
        #region Day1
        public const string Day1 = @"nine92jnhgqzctpgbcbpz
sevensddvc73three
9986fmfqhdmq8
7onexmxbzllfqb
six777
1zbngsixxrfrpr
threeeight9seven
nhds975three6
ninepgp9
22fourninetzfourfsnxjglthreeeight
mhcvqmsg7bdj
seven67
fourone5
twofour7
5sixonesix3pzhd
3htvgrzpznhjts52one
52cmzhfrxdfmtgvtfqx7three4szcfchxj
sixtwonine7
three7938
67four4
7zr9
4qseventwoqqf9bbqg4
sevenone1srmghlzg
ctwonenxmhspdmnineone7
8mgzsgmphgceight
ktznbbmkbhln4six
cbtpgzc4
rxzgrqeightseven18five4txv
jgb95ninetwonine
45mxfg9twodsnnjsfnk1five
29lhfhfkdqfntwo
tssixsixdxjzjjhq35hone
cjfjpcrpcn7rlrlrxslmhpt56189
5llmdmqgt149sevenoneq6
l9649twothree
8two34fjxt42
seven3threelxd66
46248mmfblpgql9fournine
3cmvxcskh4
491mzklmbt7bgcrbmspprjgsgv
95eight5five
14qqndrttdrlgqrhmtbninezgjsftb
nine37eight1fcqns
4onethreekzpkpkpmxlpnsvqtlmtrsgznxkckrpsqskbz6
9vvcsgxq
nlvfrjghsnbnine19
pdxlsxthvmone25eight
613twoseven9
123fdx
dnqgrzzmxxdjzknc3
twodm2
thprcxhggclfnlsixzhl863ninevzzvfvhz
1fourkbfhhzclz1
5qvtpll6eight1
sevenfourninedmrccgnbd8ncbjjm
3threezv6nine
kq279fiveoneone8four
nlqlzbbnrn2
8jqhncbfsxvrrqxfkv
r5onefive
znlzncgngjlpxhmmmxprseventhree7
jkpbfpvssixxpfjcs528
four4fsts53fdgckkz
kjrkflhmlk11psixdhpxbstklx
4788vhrlqltv
1zntp2
9htgdlbktwo7pthree
37dqpbmqxssvznrzp2nvzcvlnsdoneightq
zkcjnc6zgsrcmvthcjsfgvbtxh
8seven8nine
vnx3
7dkxxq6298
one42
qpjtvfhsnmonethreeqpc5
2eightlsbsrkkcp9dmmg
818twoseven81dtjrkgvfive
4nine32kjgpljzskthree9
ninedkxkktxmr1ptrlpkbqqhcjvfszseven
2573
bskfrcfvc5
3onevjgpjbqfgone7
xp55eightsixfive42two
eight64
13two8zgdmtgngdlsqzlfzskst
zmjdhkfdnine18rkp93
2onefivesevenrkvqqp3
47xvdflvxvgvqnqdxj
lvrnrbmthree6
74j
xkrpgrvrn6745ninefive
839vhbgvnbcmccbvhsm
6128bbzq5vdbqllshr
37two
one3lttgqqdmtpmbzbxqlrshvdpcdgcjhtwotwo9
fourpjhbseven89kmpzmdqceight
twoninegzgseven5nine
pfflhh6gvlrkrdscthree
8fivesix8jntbb
bzxt439
8tpcq57
6onethree
nineqm9eightsevenfxqqcnk4
9hcxcjfmbb12one6cfvnbc
37threesevenzljkqzshqkcp
trnrncrssxrqmlhbglrspbzvdtlonegtv4one4nineeightwodxs
21fivedqnjnrjtlk2fkkzf9sklbpx3
hqptwone85eight7lgq
4seven7
6seven5three6rmcphxdnh283
8sevenmxkhgsq9bfeightfivemfour
7two1six9smnvbjhfivesevenseven
5hrxbglgkn46grstkdbmzrxp95tt
cfdqbjtwoll3fxvseven6kzfzrblxp
qnhqbczqp7fxc2two
sixsix4sjjdjlxnjgcmqsrzvzljvqhlrrtvtrcqxdzdqt
seven36fourstbzj
zj4fiveninefourtwo2
5rqpmvlp
3fivextckgmvrsv
threenlqhqshmk31eightsone4hbxfnvf
975five7dzjcnsrvv6fourpjhghvhlxx
nine82plfjneightsevenonefive
five21
bntwofourrxt2tdrscfzdg
87fivetwo
2threebnpvtrqqnz5prmsppgzdfhnq
6qgpnnine
2vkvg
5zzqxp
sixxlkrhpfptqnhtkq1sevenqbnnnjfsixnine
4eighttwo6lsxpczhcmxs
kvnzcjsbsix1hnineseven
gztwoneseven3tnxb2sixeight457
four76two9eightfour
nine1nine
14lrrxcds
twonqp5gpnbkbeight3
fourthreebnjghhlhkhconegcssjrjpbkcghxtxssix4
one57
zkjkzq6sjztlrqrjr9
seveneightsqjzqgnj69eight1
44tvjvzflfc5seven
26threemjdghknrmv
nfvg2rzcrpntndp2xsglskninesix
nqdpzsevenpfxhvzthgn3
2onejxpzf4zzktsmszgmpcfsstm6
xx89
76qseven
jsevenztsdb9hhmcdbftq
16one7nine
seventwoqdkcbhdpmmtworljxhvvbh1
jzbvvsmd1
1ninesixpvcdkllhzbnrhqmztzeight
47pmnvsxgvgbthreenine
two88nine4sptjdbpl8
eightfxpg9eightgmzmtmcdninerbbcpfv
fourpfkzxjtqffour4fourone
nine5fourzldszlp5eightdhpmxfjqp
onetwo1l
zjxcvkgdvm83
lrbsdhcthreembbcxsix6
eighthjtndgmqsixeight9xcbkfkcbgcscfnxrdxglb
vfive9fourcmtpfour
sevenonefour5
rgf7kgdskzdlnmvdccpgphfzzz9six3
five7ninernknr
cbn5fxdlthree41pzzkfive5
two7eight2p
ninenine11qct7five5
zsrqtvkrlc2gmgzshqmrkgd63sevennine
five6six
threeshpvfrcjc3mddjbmfxqrtpdxninemscsixrvvzp
mrrmmvgk63threethreeseven9
pjsdfkzmjnine8xqsrm
ninefourfive1
96twonineqkdvnlmppxnnfbxltq2bvsgvckczk8
dsjbhdnseven1grgfhnv2fourzhbzsrtb
4zfzmsmd6sbkx1threedbx
8qqfdnfive77ckhjpfx
zq5pdkmp1d
one285seven
2hg99slp8
5b629cmr5
8mdsmlqdl7
11
leightfivemqqcgdkmgf5bnh
six44jsjglrb9bkhjthreecrvnvkzp
4c83five
vkplqrvclg39nbxrdxlf
zk8bmtnlfb6one53five
32sevenonefourshgllvpcx7ndb
eight937
four5rntqrhknd
75k
five1pqtthree7eightwogbz
lplnltrj3
eightfbqknfvpnq797z
six347sevenddrtmtbfzc85fqmtg
7twoqjzfm56rxtwo
vcnxgdvnlpcsxnf5onesjjsh
tkxzgtsrseven5eightkzzchsttcclsrj3l
eightgnb6brlhgvjqqtone41
seven6two2seven
rptsrgfgxbfivekmczndhk7
1fourdjmngvm6
92two68cnpqnksixthree
nine9lzjhvqfmlbtvhpldthree6seven
hfggfbbone5hhsdplqlbtrd
419
oneszzlpcdthree3psbjhtxg
72sixqblfhxttgkt
t3vd96eighttwofive
6onenszxmlqmddsevencmqskr
cnlkqsjthree7sevenrfrsxqm
47eight5seven4
five273gvq
8bszrghjsgplgq2vdjltggpv5ngbjtsxr5zmqht
hmtc5onelbxllblcbd
seven436cjsxvxkzjpxfzfvj9
8qcrkfqnfck957qklqkh3fourfour
bhtnrfckfone9six8
fgz3seven
2ninesevenpdcpcjnine2two9
vgfvvjhb6jqjnine
rfsndn62
vldqdctnonenine3threeghxbvmdmlgcjpfrdjnine3
two677eight
6ksn
762two
ldppf75nine68xnf79
eighttwoh5three
nine1threeseven
seven2kxqxgksevenhhsksnkhqcrlrltsixcnszhmn
lhbjnineseven16eightrmjgxdzfour
onetwo77jtgtnqnc8one
four7ninejxkqnhqjfdzrjdhggrvfourlh
qq2brmqcccqr
nlsdfour5eightsktbmxlxc7
8fpjfstnbnineqgkbxtl5dqdnjqnlz2lcljvfbcl
g6r
6five6sixvjctzjkksbrnkpp3
1four8sixthree32nbbpjnhmzp
2md
twokxhkggninengbfjmdfc76
fivetwosix446sevenfkgzd
57vflrqxnbcqfour3hcjhsrrrxkpjxgvfive
svbppr8six66
twokthreevxdfvtmpjddnl8
sixnine1eight44seven9
scsmpjjxlzjf876
74qhtxntdkz19pchjtlxclm3
seven8ninenjtvkgj45one
bkseightfourone4threeonesnb
8two8xnglszthreeone
lt771782
one5cfdcnz
zgsqfmxdkbnhsbgzchmfdrpmkvtzone1
jmcdgvjnmdhskfiveninevbczbs3
kzeightwokpnjskjhseveneightkpjb72ninecftgvk
7eightwogbb
54kvfvmfcbxbd
3threeninegrlkrnkpd
phbqqhtdtclfzph58sevenmxmd
8twoonehcnszgqfvxxrqrjctc
two9nltzxg9nine
9vlhb4six17zvgkmh
5threetfdvtthreebgthree
49ttszscztpm
8seven6
three5eighteightlvqll99
nxkt5zpctfhdjpvtwofbjdsrnnrvjbjtzgmkmrxpjmntc
11sixfivethree3ninelv
9gszhbpgfjrzvrzgjfsixd3
jzxv89two8bjkmqmngkgtwotnmdqeightwonrc
qxeightwo5hzpdpzzcmmzskjzfmgpftlxkmzgp
hvfmrxrlslhzkv5
6pjzbfbmone1
768gseven9sixseven5
qmkfslbrcnhtc5two5btgrhbnlx
sevenonefourkgtd79rzfh4eight
9fourvmvbxlvlm8threefour
9sdg8
8bvrkzfxndjffltghv3blgpzjjckjbqqsqeightqj
qc3jnmtsmpzzjbczbfive
sevenfour949qgkqsjtwo8qqpsvzn
dzlnmhd2rflthreedflj4
sixseven1
one6sevenhtpfgpfxfb4vjzhseven2
twofivefxdc4
3fourrvffbkkcmxggsevensix3
djkghxsptqvmztwotwofour13
4b
rvgvhpdtwo17xzbxnfjrmfjqxf
sevenlzsrq6oneightm
qkxt88twohqzntfcsfournine53
bmcxgsdjtl2
74htmkdfg583srrlxbhrjv74
sixseven6tjtsthqsr
sqpkddjfvfn2vpncllssfqlzjkcfivetwofour1oneightltn
6smrndvvbhkzpffzfggvzfznzvmkmglvptfour
45fttcdmvpl
862
xmtmbzrtnptwofour3vknngpgt5
8fivetwosevenk
twoseven9mgzxbcgxvm4f5three
1eight1
dlone5dvrfrcdmjh
9cvks8eightscbdmkcs
qcgxzddpjljmlzgmt5nzxhnsthreeonefivefour
grvm8kktsfczpkr16stfourone
9onexmznhhtrjrrffmtwo
seven4threesix3rghsgxlxv7
7twothree
1eight66sevenzbpfpx5nineeight
tdhnbdm5lklnqprmhfnsfndlmqz
gzznvrjbkj7lfdjjsqrmkvtfrdxr
sevenhf2
eightthreembmlrcnseveneight4vgbgpsvnklbc
mxf7ddcninesixsix
rkskdbpjj25djggzzznineqsfftrptseven
zhklmmknrlvqhvjl1
two37twosccseven
2pmdscmvfdb
2423six
eight3484oneninevqzdone
91sixeight
2five4mcvktqxg
mkqzbxmqpfouronedtrtvtlh561
ninetwoqcjdhgfrsllsbnh5lcsixdj
3thmpnfivefivehvjmdrgpzcdtwo
sixone3
qxrpbbq8szvbxzsctwo8b
9zl4nine
nfdnss4nineninesdtxhhbttnjv
7onevxltxxpktcfgb8two
jjgfive4fiveone8seven
ndnmqfour87jgxzhxsshrpkccvbkhfjbvdznpkjhsfgpgtwonebjc
54qdhsixthreeeight4
five2mrlthreefour5dstcdl9
2sevenvrxkfkhvrqcgj
six9one3ninetwo9
47twoeightonesevenfourseven
4lxjndxb
twoninejlhjnmv77sixthreehfmxnrmsbb8
5phctbfzjttxbmtqxhbhdjzlsbtdqhjcsqhp4onedpmvsqqxhh
2zxfhnlgfg46twompfpdxq5rkprm
chfgl5hvrhn3ninetwo1four
6fiveeighttbcdxzplsthlqrrqpfnljlkh1
7nnf6seven3gxptj3hpmddeightwofgz
nine3one7zmjfdxq
onedlpzjnxnine6nrdm
8four24sixdtgvs
8sevenmkclfxbgvzjclfvsppcnnrone
four9nbhfqvrgzcxcvmrtnp55sevenmzvllfsz3
qjfdqhhqfm552dqsgpjxzbdpqbcqlgsd
5kgfvcpm7
threegvqdkvht1two
h2vmd
4nzxftfld
sevenfive8vjxxgbcktb
qnnine2seveneightsqcsnx6zpxtkzxx
hsbjjhb1
9one2vfpnhjs9ninekqjp3
eight8ninethree
34q78ninesixnine
nine8threefoursixfiveninemvrgmnfive
2eighttfzsvsfcthreezlspnkjp94vjtgnlvrr
68pbjk2
ctxpk65cgvdjvdhh8
mchjm476rlppfourtwomht5
dltwofourseven5
2vmfdspgkt7
28sixninefive4vmddg5
2rtcc
cr4
5nmhbslxxtmsevenxn
sevenbzmbtnzpgj8eight
5qn
4phjbkmsjvskt42four
six1four37twoeightnjgrsr9
eightone4zcszcktgqqlvfspzbbgzz8
noneightphfdl78ckfkdmlnlktcrp19
3qfive9
416ninesevenm8three9
36thprseven
ninem1
sevenbxh6fourtwosix
7threethree
kgsnqrpfourqllxjlhmphxzs5threetwokqlqtwoneqv
dlldzdvl4four7onepmpprcstx59one
threefhdhmgbs6
ldsxvtqd2dkkn77
six224eightone
xk7fourj6
sixjhpf59
1threesvrfvccqpnqzvhkq1
44five
one61
twoqxqlkkrfj7six51sixjfgjbfx
4bdldfqtb6
xrftwohszhtkhq9
threennsixfhtgpvdnnx6kxxcpx3twoone
grhbqhtl5threesevenkscph
sevenbrmttfxrlm9kdvmvjgbpz7
26one4one29two
fone76nine
four62
6eightftkdjhnqdsdpone8five4two
mpqltxpzqfone1ninekthxjqjf
vhzvxhtlgvvpfjsj16
pcqq88lkdjjllthreethree
zpbzdmfnceight412cxzfxpd
two78jdxcjxrshsxpxsseven
1877
4fivesix
seven379threegzbz
eight78jcnzbzzbdrldkf
dtlleightpqdkdmtrm25rngsjrrpnhmsnnlcc
fourthreefourfplmfqkqxztllvninenineseven2
8threefkdfmltrbq
sevensixmntmdgcbnfsevensixtwothree8
25twoeightjrp
sevenseven3onekrbjcdmfbsf
sz9224xmsrxgj
jp628
ncbj7nine6sixfour54six
zlnpvd24vkstwodphpl22pkvdjxmdc
9c5two
fivetwo6531knrdgeightnine
q7onetwo
7lbztvgzdsh6sixseven
sfbbr8ltlpldgft1blxctbzmxfourmbp65
dkmjpbbbc3nxgdpqfx
sixfour62zlljntpbnine
3fourmcb
8ndvk8vdfqjj1m
c8vthreesix3twoq
eight2rseven
1cmxmkththreeone3eight96qrxttfdzlg
2blxxsh19cklgghmnjph
qgxhcrkmthreezdbfpgfgsrdbheightfour7ninetwo
4sevenninesixf4fivekkkbnjq
sevenbzxghxrrbjpspmdhzqg7five
one1sevenkltpqgjseventhree
6fourtwopfzpng
8msfjncfjnqpds4rqbdxnine
kcpvnzv1cbtnpvone
fivenineeightmthree8
zqkjeightkzgzbone51
vxlglkpglqhkjjxlb4
tzjqjzghthree6
one1qbhdshmqdkfcn
pdrqnrxdz5jqjsnhmt4five3seven
46rvhnvdbmjrzzffivefivesqkg
oneprjnclrh9
twoseven78j
rrllqrpdhcznns9seven
pjrqzbd7
978seven8kmlznczcrbplnjvtwobgbrtq
sjdxrt12qzvnpxqgrfourkfrhlzmsqplxpcqq
1jfmntl1twolvtwonef
hd53eightsixgtqdkbjfrvqv9lxgg
1rtbzrnndthree7fivethljmpzmscgjgpzpkffmrfx
6rlllxpnp1vgrdxvfqzeight298
99threebrlkkzsffjlltqtwoeight1two
7sevenjrjpkphkfhfour
four5977qzktpnsixncfxzdghj3
lkptwo856
7cktjpjbfnplm7pdxrnfknfmfiveglsjr
1eight5eightmjhqfn
zskkbkn37k7one
6fivesevencpmlpngjfvfivesnhst3
five8cqdzm9
pfdhzfive9
5seven6ncmtzrhdthrftmbnkzmfour
89tkhtdlkg8rjjpfj
9pghbhntzntninefour
eight3ninesjc8
79one1
45lone2
fblrgtgdvfour5
8nine139tsgbqmoneonefgqtbv
9eightvdpstdhtqfdzhmpspf
zgjfpjxdqbzvxj9fiveseven6vfntgjkgr5
threedscrseven911dvgcftsdklfthree
threetbtlnb3mzlmlgspdmqxt8hsqsckxfkcsix
3dtctvmnh
foursix6
8eight5jtfj
1lcvtwofive1qxdqmslfbndd
fourthreersevenseven581
rgpthree747hgzoneightzs
fxqdbvtjngr3rpxrzfdgrm
tsmcsl2one9ninesslscfivenine
1kg5three94
8pqdqqddhn81hjjdjfsk
groneight1one572seven5three
krgdh94
3zxgsbgn4
7vsckhgjvxd3fourgjg
6lhpsnmtz8lxcgqzjxvjxpbbsmn6rddljdthreecd
386fivensrl
one5four487eightfbsblbkthree
bhkvlqhsqjpseven88five19
92two6cpz6
7nvkv8719rznhq55
12cmfkmvknqqsnjsqv
fivehgdqqgrcx2xflqmmjnq
vmpfivexpfjscsrjh6fivetsqngtzllteight
nine1bkbrsjrxkgtm33
7one2
31jdx5seven45
one721
3three3xmsxzrfl
6bjz7shj45two
zseven6nnftpnxldgtwo1two1
266hkvrtbflcthreetlbrgdnhkrseven83
88vmsrsvxvpcvjmfrpssqvcjqdcmxone
773sbl4
86ninelxr
jjbgmdmrfive651fourone
seven5trjbkhsdxksevenfive1five5
1seven2drllvgljjt4
onefkltbmnnpfnqsjtmmkb1
threeeightthreeonerqzx7
hrqfpsdxf4
82five3rptwothree
57fourthree25jlxqrbdfour
3mq13zjzzgztqv
31mdzczk44
hfdmvpxr925s
fourfourseventwotwo4twofourddc
1six5foursixcqtnvmh
two5sevenlmz9
1ninexrhcxblntnh881four
35dlmjrzrzqjgf9
4six1vx
fiveseveneightsixtwoone4
3bxvkznxsqmfxbqsix
mxkj2six
sevendggctftjtwoonerjcvonesxn4
3xslllfzsgk2
1nine3seven
1bbeightfour8gsvtv7xzqqgsqt
sevensixfourhgmxsxndvk3
6hdkhb5fxzsgfivethree
nine797msnmphf3two
snlbgb7
753five3st15
3foursevenkjqldcdvreightseven8hcrqmtdkkx
qdrzr5ggslzvfnfk56eightrdvzmlktj
nhlkccvhtwokprngjkonelhprvsp62
zqmdvsxpxccgchmd1hprbqkrbn299
oneninefive1
7twofive4sdzj73
stwofive53
threejsttgvxrhqmsctksn8oneqfour
sixfqvfztln51pqlnvvlx6jkcvkmdkjxnbzfdmt
zzcrjdhbglfrgzxjkb3eightonetvlrnine
cfdz4frpcbfvsevenpvpfoursppzj
9four8nineseven5fivemgsqxj
9onemsdkpvhdbprzbx54two
bhdsevenrbnfxk6vzldmgzrqdeight
2pgbh
2qcq4eight516
45phskdfcld9gmxbkzdsix6
sevenmxtwo1sblmbnhxrtzck
2pfsdqtfkplkqbphrhdoneone4five
957zktcl2
41six
five27zdfqxkkvshsfbjm1txdsf4
sxsmmzcf3lfrmpsix61threehbdqnvsix
qppcjbnfj4twofour28fdj4
one9kxxtd8r
fcdeightwosixvhktbjjht7five47pxdtnq
gdkfivezptfjxxqfnxqchjg3jdgvone77
2twocbzt69rm
7kx4twonine5
tlnkgxzcdf57nine
4tjcdv1
5kshzgbs1one7fivenine
gxldrzgctwo2
8twoninefqmq3dsqxv
9ninefour27threeseven2seven
15fctsthreesgdnndsssix1npln9
2sixnsqkzt16eightnineqg
zgrskbjbfsixfour9eight58kpdzxm9
fourthree8fivejgqvdnc
onebgjjllzp5gvcxjsxmone8ninefivejgghfpvxxf
4lxgbrqvsb
86bvrnqqrdmrxdbhtwo9zqnjkvnqkleight
oneqt88
onethree1
twosevenfour1six67four
29mnfpjthxdvnh
nlhnine44oneeight4six
1smpfmdsstqcn58fgb
tkpd53
92twoninexkhcvl1
fkccpninetnvqvdvlkphknh9
zplfcxsqhbd7rxmvjdtrngzsdrxtwo89
2gxxckzmgthree
fpnfttfvmnfone8
171five
4bmtr8
153fournineeightwodq
zkkddvk7three4sevenv5geight
512fivefqcmkm1threesixcxdd
6moneeightfpjone29ppcvf
37sixgrmmzlslbxnxmrdtczthreexcmtppqlgskrxzssjcln
dponeight7
vxfphnfourqzcfxkbsv7rzpmfzrbkm4
1nsf648
214twomgvvkktbfrzone
threeqdzhfxkr1nmxxlzrpvtwo7
8threefive
snrcxfcv4
964rngbmt
one5kz4
116nqmtvbcbninefourninetwonenkb
3cvvzsr
49ngfjtwo1threebcpg
pxxjsfmmpsthreeonesixfour2five2
nvttlcr9sevenxszkjmjzfzqtzznptzqbvtsix8seven
12sixjpmvfptmjseven9sixzmmkqnrlv
hskbdlf3
pbxthreembsnnthree7sixxfnqdcvrzj
66866eighttwofivesix
mvgjhxzbtxhpsthree9xx896
nstdhjsp1threethree85five8
zceightwojbhlkl4
2bbdmjvqbmmfourqtkfgnvdq
lnvrtfplvfseven65
ccbslkf5fiveonenine
nine7xfive
92threefour
5jssd4pbft4eight6
stvcgplkppgrdrkjtxstch3svxzmkjf7
hmfvpctmmg6
192oneightggr
18dxpqfcz
xccgpvhhseven5qflqfourkhsxqdhrbscdmbj
4jdceightseven46
ninedjtjsix7
eighttqcmmkgvhc67
kt82
dfnjmgjsmggrvljm8two4
2gfsveight
nrtwosixninefour55
3threesix3six89
twoseven5hzqsgdvmphnlppt1kjxcvpfsoneone
4fivethreeone18five6
l8pone5jtfgxffgfrone7
5zmjgtp2pfshdlonetdflhrz7
5twonepp
eight46pmncqjdnkbz
7ngmcqsevengzeightvthllqpxbfjgkc5
lvscttxkct7eightsdkxgffxfhhpdppbgtzbf9fiveone
352threedzpjvtq7onetwonefg
31eight
6zbhrsnzsixxmjvsnfsixnine
tbgdjscgtkn8pdtld
643nbsntbjmbninezfbnkggfivefour
vxnsvnine5seventhree2mksgsjbpkqdgbs
2xchcfiveeightrnldvblbfqnmvmn
5kbpnbtpnzbeight9
three2eightseven
sszgqcvtmlcmd95six1jmsnfmfmlktdvtskrp
xlmthreemdrvgzfnseven3
ntwoncnpdjg8
sevenfivethree968
four6twooneonejmxgtzz6three
893jfmmnk6lmhqmtxgkmtxq8
pvconeight3dmprrnmj2cpqmgmvkqtqcn71
five688seven
67six
54xcthreenlhthreeone7
6bkt4hlhg7
kvxpgcnqkhkhxthreerxkxt9cgcnvcvkxdddsdfjrqmn
4sixseventstk3
qmoneightnine583crcfeight4eight
7sevendxpckzsm885
seven7threesllgfvccbglbscdg
ninefbnnpvxcmjpjrts3eightzsqmxxkkgg6
nxhmxngoneqqqxlbqfcr5pkpthcdxtx
threeseven5twocdzkpp
35sixgtqzsnjh6three
sixrbrdblgj2prpsgnl9686
2seven2
cdh3
sixtsfive8pdfivetwonegg
ccsbzxsevenoneeight76
jbfkngpjlvbtwofiveone1pdphmps
beightdcrtnchtnine6fourthree
sixsxzonenvvkljfthreezhp37
seventwovd17
hmfs69one2xeightfive
3sbhjfkjtnlrzqrcrbkbcxzcmsm69nine
njdkcdprjgpn9fs
bg56ts
one542onetwo
ninernsbhqzqc6one4sixgsdcfsix
2onethree24onetwo
8sixmclpsdvvgs6eight7lnzhsgzjxdsn
one5onefour
c1fournine
nbqbgxdtwo8fourxrgszvbxqtwo2
9nineffsevennine3seven3fnvsxmvrk
tsp5
oneseven9threesixgjnkv
fourtwo4two3hfnpzhvcx5
15eightsthhfgsjtqcbxvxqj
jdvssqjd9scqnlsfive2two
three9sevenzdgpjqkzh7four
8th632onezhfcv8
7sixlcxnhdmphbbbpsxrb1oneprx
four4eightnine
gxbsix7pqkseven
4teightx3five6eight
sevenzrzm72mrgcxld
7foureightthreesixqcddc7smksqzxhqs
hpcpqbhsfivesixninembvbpqphhmrtthree9
ninexzgctccxbgjxvtngxfvkthree8
fdmvqcktrjh8fiveglzhchx55khhntcbndddtjccsx
8fivenine
mxsbjjcbpceight18
vjvddlttpsgbvf99
5five3
jrbxmzk46threemmsnhflsqfsfkf2
gzbpgvmrqninethreedhldl1slvnrhr
nineptdnkjgtsx9
3bmjnr3eight3
8ztrxrxrkc2bseven3five2
six8one5eightrhmmxmhfour
9fourkdcff9xtnhcrjconevvhplone
five94vkxzcqone8zxn
7threeseventwoqzcnrslbp
gtcbsmt52
8nvdtsc8pxqttwoone2
prlgthreesix1sspdmqsg
vmppqvn1nfpmmzrfzfbfcvzpjjeight
27sixhpg1fivefxfjxtpggzlqdgnv
7sfjbc5qtqgjvf
7twotwovpnine
cmjkmgszxcc37hfjnpqpbjqseven4
stt6ninermjlgqnjhghsevenqgg2
4onejfppfcnkrceight
five6kmzzltwo
524clmmrmntxrninetwoztseven
4ll
fnppsrt9
seven1sddcbgrcl
72ninejksevenseven6fournine
threesixpjnheight5rsfkhqchmvqrjck
eight45mnhmkqfourhmxcpvjgnpg
3pxrhxkcdonemrcvhv
one97dszxfbmx2
7pdsrzllzfour1twothreeglkpnckq96
seventwo18czcxpjmtms4six1
bfeight3zjdp1
ndrvltwotbcvzffzml9
nhfq4two
8mck8oneonesevenone
zdvkq54
mxfvps1fiveonejvjsnsix4
skqrqdrphp89rnflzcpnrd
eight382km5
fourfive87785
fournbg5sixnine
8fivebzknsixdqtcgbxmfhonerqzlnqs
24six3nbjrjfhnbz8seven
sr9ninetwoztcmhhdone
nine6nineblrlmsevencrchhjvlrsevenfive
1frvmqxkfphpqmvbftffxx5seventqsvninefour
8fivesixeightnqqdxgjprjqvb6
xkqtnxx5mmdqdcps
96dpbz25sixffzxftthree
88sixvxdhqllvsf146three
51eightnczdonebgfrqjp
eightthreekgdgjlgtkfour242pjjsllpq
ninekxtfournzgqf3djxzgxsixjv4
84msnmkzxtszrkoneeightsix1gzp
two49sixtwo7cldmnrqrtwo
88seveneightgtqmdtjss
threebzqjcthree1ngmsnine6one
rtvzqfour5oneightkm
tfjgntbmhpdvkb6
fiveeightsix3one
tjgkznfourzmbzcsfjvlqhchq1ggtqtftwo1
3nmzhvrmpfive
2threeonedhpldxrclssrmvhgczkztwothreeeight
lldsseven25
grv2ninezhpsfoureight7
five3tdkmkshsqfour
two6tfxtmzxffive7flkpkxvssltftxqhvqr
2mnlpmb4fourpjrvpddtl5fourseven
xjrvkqjmsdcpnbzf25fbbbxone
lrvdxjv2eightvhgzp4ngctthreejrclhcvjvqjzqg
1mhxb61onekpzfjzm2nine
bkjoneight88fiveeightthree
eightsix1tmg4fiveshvjxxpvqhnhc4
9rhbrqnghqzlsfmgfxdvfive98
9six2threerc9sixfive
19two33kdqdtqspcqhbcbf
qdvzs7t
3fbzdmtpqktbqhgkone4
nine4threelzxvqztwo9threerpfbhrqm
858
1csgrrbrmdseven97vqzlngxksvltzvtlv
dql7gfvx37six
onekkpxclxgff7vdz
71three7eightqtxvjjdsjp
znnzvrttr8927
1rmpcjj
tbeightgkjhr684
2vzkdvtrrvninetwo4ctv3hmdqjbone
5v998six2vqkb
2four7four
7vxlfive3dccj
91five6ckcshgrxkrgztmv
886v22
3vqjkkhdbjccffourone
lb4nine8seven6five
658twokxmjfbrj
2onevtdmdnvkqpctx15seven4
vcbheighttwopmkzsftone7bsfds7
zcgfive2one8lfbmqg9
ninesevensevenrqbtzzh96
1threehsqptqjhkkndxpd44gzbdlmcxq
sevenvxdprjvkh92xzonecmkljhbcnzzfkgjpz
five8eight8zrrkrvbjzcqbtwoeightwogvd
2mdnmbdvzxfldn1eight
tmbmzsbljreight515
rqbtxhtwoeight71seventhree
gszsxrb7qvmkb7478
ceightwo9cj5seven
89eight9two
5sixjpcxjrrnjdthree
two1r38onesix
6eight9l6sevenzjcht
fivecqkzbllhshphlseven4ftfivevl3
69kbqvdronehhczgmvh23
sfour1lgv
4kvpgtmsix
4vtdk3
7vfsvrlnlpqmvmhfnp85sevenqlztpt
74cfpxpxrzfour3fivenine
sixsixone8eightxl
gjneightwofive3
6twoned
jct8343
kcbqqpv4gqqhvmtcpvhpcngonetwo
sixtwooneonefivef9lkgfr4
twotwosixtwo3mltrqnj1
3onezgftz
14ngxgtbfivefour97eight
2bhgf268fivefiveone
znoneight82lbghbsdktoneoneeight
53dqlrxmb842
1mj1ninefivesszgqp4qk
7eight2qslhpns
gpqcpfgfpbnjpdf2
threettgjpbspfive948zksmone
tlgkjbrkzn577fourvzrrndxdst174
szsix9hqhtwo
4fivethreermvhkpnrs1zqpsh4eight
one1gtnpmsevenone
one65tvrldjxngeightxndfptwo
58xlbvgg7
bhoneightsevenseventwo9threecmlkhdj5nine
fourfour4
68mvkpvpfmkg4qshqmccprone4
5foursixmf8fourfour
lfflvxbfivepmlfvfxeightninefouronebn5
eightjvmbbmpfxs9pxgk98twofive8
msnrmphszone2vpjscthree
fivesevenonetwovbkddshc9
279two1onefrh3five
sevengxfive3six3
16pmtwo7six
qdkrjhjcjl17sbfn
321one88onejvjtfour
4csnrskq
sevenone39five
23vnmrdxh7threefour
77srhjdccjnineseven4gll
vrltwonevxqdrgmpm519fiveseven3
8zkqjrtrfbgthree
6dmrhjgxeightseven
seven6sevenhh
nine64slonetwotsxqbptkrseven6
3sfpsix
sevencmmnnzltcpvptnineqmklpttgvcntqzrpxct11
3vbxntfnsfivebjkpdfourseven9
9fivefourhghdlxvgonelcrfcqgpq49rcchgq
vjfsgrqhmxjp62
gqdbm4
4ninebvvmfdsix
two72fivethreethree7
194fivefkdk1
gznjfrsevencvbgqptndceight15lghxgvslpsix
two1nljqmcptdxjdkvb7
9seven21sixnine
vsxgdsgxsdlq23fourvhfbbtjsfhfive9hkbbqzeightwotps
3eight417bkbmvgeight
mq25
8fhvm9twothreeeightsixfiveblqr
ddhnrb9sixh1
nineninedrnchvbcf3cpl7
434
rttj6
dcvgdcdtwo19four
8sixsxshbhmnz7three33six
xrvj7eight421sb
7six8npgxsix4four
2three9
lfqgpkbmc69eight
6211gkfbvllqtwofourfive
onexfcmsnine53
xml4vkfgtbqbckknbjhxcgdgqdtv
3bzknzmshp4
five342vdtmgseven61
2kfcmblfxb2four
sixeight5threethreenndhpvhrshgfsfourpkbghd
rmz4seven3psixninesevenone
5289
vrxdlcf937
2zpclqftm8
fivefivefourfour56two
seven7eight1vtwo3cjhone
8threethree7six75
ldkjshplmb8threefiven65slmqlrzgb
2nblpgthqfeightp
mone93
fourfive43four
1gghztjzh
seventwo18fourfkhjmzpeight
gbonecfgmrrsrcfiveblxhkcfzcbbfpnn76
92ninefourseven
2kl
9sevensixsixpsqzzndbdf8twosevengjddm
three25frjhjfour23mhvzgcxgddfive
blhbrztvhlhglcrsbfour7five3fdxhdxpvz
qvgkfmtxhd9
seven4mqt
6fzcfcngzfivesix43
mjtwoneghtth569sckx53
seven75gkvvrp
five1onethreeeight4522
vjkeightwofive1vspseven
14ljczbshdpeightseven
3mpk7fourgrqsqnrj1
rnlvpksckvbmzfqhvpxxmm6djmtwofourmjfnvh6
1six7tghttbfsevenv6four
1nineeight5
twogxd2three
tvrnxjhg8413
7zpth44mfpcdcsixcppfxsthreeqnzgpp
67seveneightnine
bdkddcsrv3nine7
xlftwonetwo4rkt
khqtwo2tglvmvmfdhthree12three
twosevennsflmtwo938bsf
8zrgsnr
sixhdnslspbrcsdvxnnk7kjlzxrrlk7bbrjxbxlq
sixseven4572
rnvkjlz51drqdddlg7clhndmlxnf
kvflkmsseven4xhgpdbfour55
74sixdcqzj
seventhree35fivetone
72sixonefiveeight6six
ghrzthqfhsp6five
5seven76thprmblnxqbgdcds
925
one11
ninetwonine7ninetwonend
vntwonefive2
h2eightninetnjhvfive
2eightvkrkdjbkxbpsznzd
4psixfseven723
vctwonepthree49
xmqvn1jpbjx1sixxznflzk66
trkkpm881zqkdfvcnhsevenzhnseven
fourtwo5clj2
2xzrclndckseven24f4
eight62
twoshpjzqcf7
twohbkkrzvpxeighttczsls4six5nineeight
twoeight122gfhfpzhktffour
3htbjtzg8tsztldj
sixtkbcccqqvmzfprjngxnbrxfk9t
267seven
qfqbpzjfour1djfd5zxncnfnfqqpc
qqb5threevtpktwosjjpzxnntwo
fiveseven5rtcnine
xrrcbzrtjgsqkjlnhxt5fivetwoeight
sixgddsix7
zdsnznxmrbljz7lvdvx74
qbfvpnxsix3four1lfone
9one9pjtnncsqzhcszp5";
        #endregion
        #region Day2
        public const string Day2 = @"C Z
C Y
B X
A Z
C Z
B X
C Z
B Z
A Z
A Z
B Z
B X
C Z
C Z
A Z
B Y
B X
C Y
B X
B X
A Y
A Z
A Z
A Z
A Z
C Z
A Z
C Z
B X
A X
A Z
B Y
B X
A Z
B X
C Z
A Z
C Z
A Z
A Z
B X
C X
B X
A X
B X
A Z
A Z
B X
B Y
B Y
B Y
C Z
A Z
A Z
C X
B X
C Y
B X
C Z
A Z
C Z
B X
B X
B Z
B X
A Z
C Z
A Z
A Z
A Z
A Z
B X
C Z
C Y
A Z
A Z
A Z
A Z
C Z
A X
A Z
A Z
C Z
C Y
A Z
C Y
A Z
A Z
C Y
C Z
C Z
A Z
B Y
B X
B Y
C Z
A Z
A Z
A Z
B Z
C Z
A Z
B X
C Y
A Z
B X
A Z
B Z
A Z
B X
A Z
B Y
A Z
A Z
C Y
A Z
B Z
A Z
A Y
B Y
C Z
A Z
B X
C Z
C Z
B X
C Z
C Z
A Z
B X
C Z
C Z
A Z
C Y
A Z
A Z
B Y
C Y
A Z
B X
B Y
B X
B X
A Z
C Y
A Z
C Y
A Z
B Y
C Z
A Z
A Z
C Y
A Z
A Z
C Z
A Z
A Z
A Z
C Y
A Z
B X
C Z
A Z
C Z
B Z
C Z
A Z
C Y
B X
C Z
C Z
A Z
C Y
A Z
B Y
B X
A Z
C Y
C Z
B X
C X
B X
C Y
B X
B X
C Z
B X
A Z
C X
A Z
C Z
B X
C Y
A Z
A Z
C Z
C Y
A Z
A Z
A Z
B X
A Y
B X
C X
C Z
B X
C Z
C X
A Z
C Z
B Z
A X
A Z
C Y
A Z
C Z
C Z
B X
C Z
A X
C Y
C Z
C Z
C Z
B Y
C X
B X
A Z
B Y
A Z
A Z
C Y
A Z
B X
A Y
A Y
C Y
A Z
A Z
C Z
A Z
A Z
A Z
B Y
B X
B X
A Z
C X
C Y
A Z
C Z
A Z
A Z
A Z
A Z
A X
A Z
C Z
A Z
B Y
A Y
A Y
C Y
C Y
B X
B Y
A Z
A Z
C X
A Z
B X
C Y
A Y
A Y
A Z
C Y
C Z
B X
A Z
C Y
B X
C Z
A Z
B X
A Z
C Y
B X
C Z
A Z
A Z
A Y
A Z
A Z
C Y
C Z
A Z
B X
C Z
C Y
A Z
A Z
C Y
A Z
C Z
B X
A Z
C Z
A Z
A Z
A Z
C Y
C Y
B X
B Z
B X
A Z
B Y
B Y
A Z
A Z
A Z
B Y
B Y
C Y
A Y
A Z
C X
B X
A Y
B Y
C Y
A Z
B Z
C Y
C Z
B X
A Z
A X
B X
C Y
B Z
A Z
B Y
A Z
B X
A Z
B X
A Z
C X
C Y
C Z
B X
C Z
C Y
A Z
C X
C Z
A Z
C Y
A Y
C Y
C Y
B Y
A Z
A Z
A Y
A Z
C Z
B X
A Y
B X
B Y
B X
A Z
C Z
C Z
C Y
B X
C Z
A X
A Z
A Z
A Y
A Z
A Z
A Z
A Z
B Z
B X
B X
C Y
C Z
C Z
A Y
B X
C Z
C X
C Z
B Y
A Z
B X
B Y
B X
A Z
B X
B X
A Z
A Z
C X
B X
C Z
C X
A Z
A X
C Z
A Z
A Z
C Z
B Z
C Z
B X
A Z
A Z
C Z
A Y
A Z
A Z
C Y
A Z
B X
B Y
A Z
A Y
A X
B X
A Z
A Z
C Y
C Y
A Z
C X
A Z
A Y
A Z
B Y
A Z
A Y
B X
C Z
A Z
B X
A Z
A Z
B X
A Z
A Z
B X
A Z
C Y
A Z
C Z
C Y
B Y
B X
A Z
B Y
A Z
A Z
B X
A Z
A Z
B X
C Z
A Z
C Z
B X
B X
B Y
A Y
C Y
B X
A Z
C Z
A Z
A Z
A Z
B X
A Z
B X
A Z
A Z
A Z
C Z
A X
B X
B Z
A Z
A Z
C Z
A Z
A Z
A Z
B Y
A Y
C Z
B X
B X
C Y
A Y
A Z
C X
B Z
A Z
A Z
C Z
A Z
A Y
B Y
C Z
B X
A Z
A Z
A Z
C Z
A Z
A Y
B X
C Y
A Z
A Z
A Z
C X
B X
A Z
A Z
C Z
B X
A Z
A Z
A Z
A Z
A Z
A Z
C Y
A Z
B X
A Y
C Y
A Z
A Z
B X
A Z
B Y
A Y
B X
A X
A Z
C Z
C Z
C Y
A Z
B Y
A Z
C X
A Z
A Z
B X
A Z
A Z
B Y
A Y
A Z
A Z
B X
C Y
B X
B Y
C Y
C X
A Z
A Z
B Y
A Z
B Y
C Y
C Y
A Z
C Y
A Z
C Z
A Z
B X
A Z
A Z
A X
A Z
A Z
A Z
A Z
B Z
C X
B Y
A Z
C Z
A Z
A Z
A Z
C Z
B X
A Z
B X
C Y
C Z
A Z
A Z
C Z
B X
B X
A Z
A Z
B X
A Z
A Z
C Z
A Z
A Z
A X
C Z
C Y
A Z
A Z
A Z
A Z
C Z
A Z
A Z
B Z
A Z
C Y
A Z
A Z
B Y
A Z
A Z
B X
A Z
B X
A Z
A Z
C Y
A Y
C Y
B Z
B X
B Y
A Z
A Z
C Y
A Z
A Y
B Z
A Z
C Y
A Z
A Z
A X
A Z
B Y
B Y
A Z
A Z
A Z
C Z
C Z
A Y
C Y
B X
A Y
B X
B Y
C X
C Y
C Y
A Z
C Z
A Z
A Z
A Z
B X
A Z
A Z
A Z
A Z
A Y
B X
A Z
A Z
B X
A Z
A Z
A Z
A Z
A X
C Y
B X
A Z
A Y
C Y
C Y
A X
A Z
C X
C Z
A Z
C X
A Z
A Z
B Y
A Z
A Z
A Z
B X
A Z
A Z
B X
B X
A Z
A Z
C Z
C Z
A Z
C Z
B X
A Z
A Z
B X
C Z
C Z
C Y
C Z
A Z
B X
A X
C Z
A X
C Z
A Z
A Z
A Z
A Z
A Z
B X
A Z
B X
C Y
A Z
A Z
A Z
C Z
A Y
A Y
B Y
A Z
A Z
C Y
C Z
B X
B X
A X
C Z
B X
A Z
A Z
A Z
B Z
A Z
C Y
B X
A Z
A Z
A Y
B Y
C Z
C Z
A Z
A Z
A Z
B Y
A Z
C Y
B X
B Z
C X
B X
C Y
A X
C Z
A Z
B X
C X
A Y
C X
A Z
B X
B X
A Z
A Z
C Z
B X
B Z
C Y
C Z
A Z
B Y
A Z
A Z
B X
C Y
A Z
C Z
A Z
B Z
C Z
C Z
A Z
C Y
A Z
A Z
A Z
C Z
C X
B Y
C Y
A Z
C Y
C Y
C X
C Y
A Z
C Y
C Y
C X
C X
A Z
B X
A Z
C Y
A Z
B X
B X
B X
B X
B X
B Y
A Z
A Z
C Z
A Z
A Z
A Z
C Z
C Z
C Z
A Z
A Z
A Y
A Z
A Z
A Y
A X
C Z
A Z
A Z
C Z
B X
C Z
B Y
C Z
A Y
A Z
C Y
B X
A Z
C Y
A Z
C Z
C Y
B X
A Z
A Z
A Z
A Z
A Z
C X
C Z
A Z
A Z
A Z
C Z
A Z
B X
A Z
A X
A Z
B X
A Z
C Z
A Z
A Y
B X
B Z
A Z
B X
A Z
A Z
B Y
A Z
A Z
C Y
B Y
C X
A Z
A Z
A Z
C Z
A Z
A Z
A Z
C Z
A Z
C Y
B X
A Z
A Z
C X
A Z
C Z
A Z
B Y
A Z
A Y
C Z
C Z
A Y
A Y
A Z
A X
A Z
A Z
B X
A Z
A Z
B X
C Z
A Z
A Y
B X
A Z
A Z
C Z
A Z
A Z
B X
B Z
A Z
A X
B Y
A Z
B X
A Z
C Z
B X
C Y
A Z
B X
A Z
A Z
A Z
B Z
A Z
C Z
A Z
C Z
B X
A Z
B Z
A Z
C Z
C Z
B Y
C Z
A Z
A Z
C Y
A Z
A Z
B X
B Y
C Z
A Z
C Z
A Z
C Z
A Z
B X
A X
B Y
A Z
C Z
A Z
C Z
C Y
B X
C Z
C Z
B Y
B X
C Z
B X
C Y
A Z
C Y
C Y
A Z
B X
A Z
C X
C Z
B Y
C Z
B Z
A Z
A Z
A Z
A Z
A Z
A Z
A Z
A Z
C Z
A Z
B Y
C Y
C X
C Y
B Y
B X
A Z
C Z
B X
B Y
A Z
B Y
A Z
A Y
B X
A Z
B X
A Z
C Z
A Z
A Z
A Z
C X
B Y
C Z
C Z
A X
C Z
A Z
C Z
B Y
A Z
B Y
A Z
A Z
A Z
B Z
C Z
A Z
A Z
A Z
A Z
A Z
A Y
A Z
C Z
A Z
C X
A Z
A Z
A Z
C Z
A Y
A Z
A Z
B Z
A Z
A Z
A Z
C Z
C Z
A Y
A Z
A X
C Y
C Y
B Z
A Y
C Z
A Z
C Z
C Z
A Z
A X
A Z
B Y
C Z
B Y
A Z
B X
A Z
A Y
A Z
A Z
A Z
C Z
A Z
A Z
A Z
C Z
A Z
C Z
C Z
C Y
A Z
B X
A Z
A Z
A Z
A Z
A Z
A Z
C X
C Z
C X
A Z
A Z
A Z
A Z
A Z
A Z
C Z
B Y
B X
A Z
C Z
B Z
A Z
C Y
A Z
C Z
A Z
C Z
A Z
A Z
A Z
C Z
A Z
C Y
A Z
A Z
A Z
A Z
A Z
C Z
C Y
A Z
C X
A Z
C X
C Z
C Z
A Z
A Z
B Y
B X
A Z
B X
A Z
A Z
A Z
C Z
B Z
A Z
A Y
B Y
A Z
C Z
B X
C X
C Y
C Y
C Z
C X
B X
A Z
B X
A Z
C Z
A Z
A Y
A Z
B X
A Y
A Z
A Y
C Y
A Y
A Z
A Z
B X
C X
A Z
A Z
A Z
A Z
A Z
A Z
A Y
B X
A Z
A Z
B Y
B X
A Z
A Z
B X
A Z
C Y
C Y
B Y
A Z
A Z
A Y
A Z
A Z
A Y
C Z
C Y
C Z
C X
C Z
C Y
A Z
A Z
C Z
B X
A Z
C Z
A Z
C Z
C X
B Y
C X
B X
C Z
B X
C Z
A Z
A Y
B Y
A Z
A Z
C X
C Y
A Z
B X
A Z
A Z
C Y
C Z
B X
B X
A Z
C X
A Z
B X
C Y
A Z
A Y
B X
C Y
B X
A X
A Z
A Z
A Z
C Z
B Y
C Z
B Y
A Z
A Z
C Z
B X
A Z
A Z
A Z
A Z
C Y
B X
A Z
C X
A Z
C Z
B Z
A Z
A Z
A Z
B Z
A Y
A Z
A Z
C Z
B Z
A X
B X
A Z
A Z
A Z
A Z
A Z
A X
C Z
A Z
C Z
B X
B X
C Y
B X
A Z
A Z
C Y
C Z
B X
C Y
A Y
B X
B X
C X
A Z
A Z
C Z
A Z
C Z
C Z
B X
A Z
B X
A Z
A Z
B Y
B Y
A Z
A Z
C Z
A Z
A Z
B X
A Z
C Z
C Z
B X
C Y
A Z
A X
B X
B X
B Y
B Y
A Z
C Z
A Z
C Z
A Z
C Y
B X
A Z
A Z
C Z
B X
A Z
C Y
A Z
A Z
A Z
B X
A Z
A Y
C Y
C Z
A Z
A Z
B X
C Y
A Z
C X
A Z
B X
A Z
A Z
B Y
B X
C Z
A Z
B X
A Y
A Z
B Z
A Z
C Y
B Y
C Z
C X
B X
A X
B X
B Z
B X
B Y
B X
C Y
B X
A Y
B Z
B X
C X
B X
A Z
A Z
B X
B X
A Z
A Z
C Y
B Y
A Z
A Z
A Z
C Z
A Z
B X
A Z
B X
A Z
A Z
A Z
A Z
C Y
C X
A Z
A Z
A Z
A Z
B Y
A Z
A Z
C Z
C Z
B X
A Z
A Z
B X
A Z
B X
C Y
B X
C Z
A Z
C Z
C Z
A Z
A Z
A Z
A Z
A Z
C X
C Z
B X
B X
B X
A Z
A Z
C Z
B X
A Z
C X
A Z
C Z
A Z
A Z
C Z
A Z
A X
B X
A Z
A Z
A X
A Z
B Y
A Z
A Z
A Z
C Y
C Y
A Z
C Y
C X
A Z
B Y
A Z
A Z
B Y
A Z
A Z
A Z
C Y
B X
A Z
A Z
A Z
A X
A Z
A Y
A Y
A Z
C Z
B Y
C Y
B X
B X
B X
A Z
A Z
A Z
C Y
A Z
B X
A Z
A Z
C Z
B X
A Z
A Z
C Z
A Z
C Y
A Z
B X
C Z
C Y
A Z
C X
A Y
B Z
C Z
C Y
A Z
A Z
A Z
A Y
A Y
C Y
B X
C Z
B X
C Y
B X
B X
A Z
A Z
C Z
A Z
B X
A Z
B X
C Y
C Z
A X
B X
B X
C Z
C Z
C Z
C Z
C Z
A X
A Z
B X
A Z
B X
A Z
A Z
A Z
B X
B Y
C Z
C Y
A Z
C Z
B X
C Z
A Z
C Z
A Z
A Z
A Z
B X
B Z
A X
B Y
C Z
A Z
A X
A Y
A Z
C Y
A Z
C Z
A Z
A Z
A X
A Z
A Y
B Z
A Z
A Z
B X
B Y
A Z
C Z
A Z
A Z
C Z
A Z
A Z
C Y
B X
B X
A Z
C Y
B Z
A Z
B X
B X
B X
B Y
C Z
B Z
A X
B X
A Y
A Z
B X
B X
A Z
B X
A Z
C Z
A Z
C Z
C Y
B X
B X
C X
A Z
A X
A Z
C Y
C Z
C Y
C Z
C Y
C Y
B X
B Y
A Z
C X
C Z
B X
C Z
C Z
B X
A Z
A Z
A Y
A Z
A Z
C Y
A Z
B X
A Z
A Z
C Y
A Z
A Z
B X
A Z
A Z
B Z
A Z
A Z
A Z
A Z
A Z
C Z
A Y
A Z
C Z
C Z
C Z
A Z
B X
B Y
A Z
C X
A Y
A Y
C Y
C Y
A Z
C Y
B X
C X
B X
C Y
A Z
A Y
B X
B X
A Z
A Z
A Z
A X
A Z
B X
B Y
A Y
C Z
B Y
A X
A Z
A X
A Z
A X
A Y
C Y
C Z
A Z
A Z
A Z
C Y
A Z
A X
A Z
A X
A Z
A Z
B X
C X
C Y
C Z
B X
A X
C Z
C Z
C X
A Z
C Z
C Y
A Z
C Z
C Z
B X
A Z
B Y
B X
B X
C Z
A Z
A Z
B X
B X
A Z
C Z
B X
A Y
B Z
C X
A Z
C Y
A Z
A Z
B X
C Z
C Y
A Z
B X
B Y
A Z
B X
B Z
C X
A Z
C Y
C Z
B X
C X
C Y
A X
C X
C Y
B Y
A Z
C Y
C Z
A Z
A Z
A Y
A Z
C Y
C X
B X
C Y
A Z
B Y
A Z
B X
A Z
C X
A Z
C Z
B Y
B Y
B Y
C Y
A Z
A Y
C Z
C Y
B Y
A Z
B Y
B X
A Z
B Z
A Z
A Z
A Z
C Y
A Z
B X
A Z
C Z
B X
B X
C Z
A Z
C Z
B Y
C Y
C Z
A Z
A Z
A Z
A Z
A Z
C Z
A Z
C Y
A Z
B Y
A Z
C X
A Z
A Z
C Y
A Z
B X
A Z
A Z
B Y
A Y
C X
A Y
A Z
A Z
A Z
B X
A Z
B X
C Z
A Z
B X
C Y
C Z
A Z
A Z
C Z
A Z
A Z
A X
B X
B X
A Z
B X
C Y
A Y
A Z
A Z
C X
A Z
A Z
B X
A Z
A Z
A Z
A Y
B X
A Z
B X
B X
B X
B X
A Y
B X
A Z
A Z
B X
C Y
B X
C Z
B X
A Z
C X
A Z
B Y
C Z
B X
A Z
A Z
C Y
C Y
A Z
A Z
C Z
A Y
A Z
C X
C Z
A Z
A Z
B X
A Z
B X
A Y
B Z
B X
A Z
A X
B X
A Z
A Z
A Y
C Z
A Z
A Z
C Z
C Z
A X
A Z
C Y
A Z
B X
A Z
A Z
A Y
C Y
B X
C Z
A Z
C Y
B Y
A Z
B Y
C Z
A Z
A X
B X
B X
A Z
A X
A Z
A Z
A Z
A Z
B Z
A Y
A Z
A X
C Y
A Z
B X
B Y
B X
C Z
A Z
A Z
B X
A Z
C Z
A Z
B X
C Y
C Z
A Z
B Z
C Z
B X
C Y
A Z
C Z
B X
B X
A Y
A Z
B Z
B X
C Z
A Z
C Y
B Y
A Z
B Y
A Z
C Z
B X
B X
B X
C Z
A X
B Y
B Y
A Z
A Z
A Z
A Z
A Z
B X
A Z
A Z
B X
C Z
A Z
C Y
C Z
A Z
A X
A Z
A Z
A Z
B X
B Y
B X
A Z
A Z
C Z
A Z
C Z
A Z
A Z
B X
A Z
A Z
C Y
A Z
B X
A Z
A Z
B X
A Z
C Z
A Z
B X
A Z
A Z
A Z
C Z
B Y
A Z
B X
C X
A Z
B X
A Z
C Y
A Z
A Y
A Z
B Z
B X
C Z
A Z
C Z
C Y
B Y
B X
B Y
C Y
C Y
A Z
C Y
A X
A Z
B Y
A Z
B X
A Y
C Y
B X
C Y
B X
A Z
A X
B Y
B X
C Z
A Z
A Z
A Z
A Z
A Z
C Z
C Z
A Z
A Y
B X
B X
C Z
A Z
A Z
C X
B Z
C Z
B X
A Z
A Y
A Z
A Z
A Z
A Z
A Z
A Z
B Z
B X
A Z
B X
C Y
C Z
A Z
B X
B X
A Z
C X
A Z
B Y
A Z
C Y
B X
A Y
B Y
C Y
B X
B X
B Y
C Y
B X
A Z
C X
A Z
B X
A Z
A Y
A Z
A X
C X
C Y
A Z
A Z
C Y
A Z
A Z
A X
C Z
C Y
A Z
A Z
B X
B X
C Z
B X
A Z
C Y
B X
B X
C Z
A X
A Z
B Z
C Z
C Y
A Z
C Z
C Z
B Y
C Y
B Y
C Z
A Z
C Z
B X
A Z
B Y
B Y
C Y
C Y
A Z
C Z
C Z
A Z
A Z
C X
A Z
A Z
C X
A Z
A Z
A Y
A X
C X
A Z
A Z
A Z
C Z
A Z
A Z
A X
A X
B Y
A X
A Z
A X
B X
B X
A Z
C Y
A Z
C Y
C Y
B X
B X
A Z
B Z
B X
C X
B X
A Z
A Z
A Z
B X
C Y
C Z
A Z
B Y
C Y
C X
A Z
A Z
A Z
A Z
A X
C Z
A Z
B X
A Z
A Z
C Z
C X
C Z
A Z
C Y
B Y
A Z
C Z
B X
B Z
A Z
A Z
A Y
C Y
C Z
C Z
A Z
A Z
C Z
B X
A Z
A Z
A Z
B X
A Z
B X
B X
A Z
C Y
A Z
A Z
A Z
C Z
A Z
C Y
B X
A Z
C Z
A Z
C Z
A X
A Z
A Z
A Z
A Z
A Z
A Z
C Z
A Z
A Z
A Z
B X
C Y
B Z
A Z
C X
A Z
C Z
C Z
C Y
C Y
B X
A Z
C Z
A Z
A Z
A Z
A Z
A Z
A Z
A Y
A Z
A Z
A Z
C Y
B Y
C Z
C Z
A Z
A Z
A Z
A Y
C Z
A Z
A Y
A Z
A Z
A Z
B X
B X
C Y
B X
A Z
A Z
A X
C Z
C Y
A Z
C Y
A Z
A Z
A Z
C X
B X
A Z
C X
C Y
A Z
A Z
A Z
A Z
A Z
A Z
C Z
B X
C X
C Z
B Y
B Z
B Z
C Y
A Z
B X
B X
A Z
A Z
A Z
B Z
B Z
A Z
C Z
A Y
C X
C Y
A X
C Y
A Z
C X
A Z
B X
C Z
B X
B Z
A Z
A X
A Z
B X
C Y
B Y
A Z
C Z
A Y
A Z
C Y
A Z
C Y
B X
A Z
A Z
A Z
A Z
B Y
A X
A Z
C Z
A Z
C Z
B X
C Z
A Z
B Y
A Z
C Y
C Y
C Z
A Z
A Z
A Y
B X
A Z
A Z
C X
B X
C X
A Y
A Z
A X
B X
A Z
B Y
C Z
C Z
C Y
A Z
A Y
A Z
A Z
B Z
C Y
A Z
A Z
B Y";
        #endregion
        #region Day3
        public const string Day3 = @"NLBLfrNNLvqwbMfDqSjSzzSJjjggcdVs
lTRGPPZnRRHszcsZdSsccZ
CFTTFtFHTtCtDDzrmBtrBD
BJldgBWnRgWNWtllSlWShMcLcVSvVjbVVVvDVVVL
HFGFwqQPQGwHrTFpwmThMbDDVcVmLvvshj
HrpHrGPZZCQrfqlNdtMlzfMltlgn
hQLhBtBtQNQjBjNLvtLjzLJpWbjJdppSwjpCCplllJdj
FGFsmccSPTVPfVVHpJJgwlJwwWJWpCmR
sFPfPFHZTHScnzBttqzvQzqZ
MNTGMTnGWvTwwwnZhNZnWDPPdSjqsSPWjmBCSBWS
RJrtVfRlLrfHgblHJVBjqqFmjCdBJjDmJdSD
tgRftftRcRLftrpHpflHlctVwNNvZNcTwZnznQzwTzmhQwQh
sQPpQpQhnlNsJpJSQphHcZffLfgLHSfHVHHFZZ
zBCvrrWzTwqzcbtbqCbrCCwWLMfVVmmHVfqHFHFgGHLZGmVG
rvvjBzTjrwQRcpjNsRss
RrnNWJJNrplbLJBBWWZstVpmtZftptfmfsMM
GHjnwndzGcqjGgqtfMsvfsMmMvZZ
cQgwHTPjPwGwjdHHTjwccQBDLlWNrLJLNrnWrBRBlS
BBBQJGQslJtcGqfgHpPnfftwqw
RDMLDWLNTLTTNjNgvdqbqRnwqbfwPRzbVHHV
mgdNgdTSMWmSQsQsBQcFSQJr
RqQhRpsdqnvdlPBfzdVlVJPM
SSZsDmSmssGZbJVwPBSzBBMfCf
LFFNGLgLHFWrWHFmLWrLWLrsQshqQnspNcRTjnpTtjRRjh
DshNcgmDVClpCfRs
TnZjTWrtrqtWnGTrbqqTTZZwMpSVRSflRMflMjRCSfpJMSJl
wHbGHrWHWrbnbFtTZcLzLgHzzgcmpNzzzz
hfWQdhQHmPWhqdhQqpdQqWtzvwtCMCRvNCwNzMtNsHsz
lBLnJZLlFBlZjGFbVjjlJRSMzzSszzpGpstSpvMNtN
rVZVgZVgLnjFVlVQDDfhcfmWrQdTfp
zqTrVZvDLGdMMLtcpR
bClsCmQbjFtjljllntsGjGWPdcRWhMppPcpddR
mbggmBtQtlVqVzgrzDzv
LtpnGnGNFtbGntbbQPhTlRpRTzDlcClPCl
mSZHgZMhZVmWPHccllzPzcCP
sZhWvSsBqmBSqmgMqWZjQjfjrLbvGbtNFjvLtb
TvMZMTTzWHNNFPsNbvDG
dhVmwfhcnhRnRfdlGsDNNGqNLFNNTGdq
JTcVVTlThmfmrrWQZHMrpZtJ
zGMBMzPNDNcNZLBzcmLvbHltDbWjbthhqvvHtg
rdJSQSTfQrRnsRfJJQHhWgbhtQblgHWgWH
nTrlpVfSpswsrsTSdnRsfnJJPBZmMBcBZZGmZBmBMmcCNzpC
nfzcnSlRJJScTZTzJZnsNjNrHQqrWBjsBRdWBr
LgHwDLwmMDCphttsqDjNNssBGNsGQB
hvwgwvghPbpggLtmmbCmSfzFfVSlZnncJTPZHSnF
DbsnzDCsBPHDQHFD
GGcWWnrGSjBMrMlhfr
GNpqddqWLqdScWqcVnCswmzJRVzVVbJp
NzPpPBppzjbpCrrQhggqvwwqRwrwQl
SDddnLcDLncghQBWvvgR
tfSLLBmmmDJGFDLJmMMsZZssZzPTzjTpzZzP
RRCrJbSfNrRQjvvHppmpbZvv
llhVGGGMPVTMlTdVzcPVHZmvqpvqZFhHFqmjFrHF
ccGlzPMVwBGfBrLCDJrDLf
VcVGZZVMlncjTqcjsWWf
hzJRtRphQJtBRhzFpdrfrqrFsqswWrmsTmFr
LJHzBQJRhPHpzQWBRzphHRQSMZlnbGMVMVnLMGbDvvbMVl
sVdHFFmhPGVTdFmVFsgPdBBtBZjSpGSvtpBztpGjzt
HCHwlncHfpnjSSpBzz
wWQwlWWlfWcQMfCrfwTRDrHsDmPDgFVTRVsV
qllqNlmglNNdzLDddGGNSHScMHMWPcPSqptQSSHJ
bhhbChVsRjwGRCbZCcSZPpPMMWJSPMtPpW
BhTVBsbrhCTrhfbrCTTTRRfngzrnnLvdzgGvNzdzLNvrLm
nNwNPnjzPsNRHpFDHLLsLVHF
MSBMgMZmWqScCFGWWDFGVvwW
JBghBwTrgchrTbQRjztQPQbfhQ
PPBpBHGfBHGpRRPDLMmnscRLdnzmdw
bMFVTNVTVjbbrCWCsndsDwjDzwmwsnms
QQbJrCCMWCVCVMShHGPQlHhghGlt
dBQMdJQHbWMWHZLRRsmPVJmppJqG
FSrzFnPnGNrlsGps
FvwTnCzDznTwzhtHjZvbdbjQfZgPMv
gJjVQzLgLvPJdMrsDsQtdQrw
hBpmWfSfHCWNfmSppMrDDMwwMbDMlMcbcB
fhphGpfNCpNSNRhGhqPVvjvjjjTzVRPzLr
TsnznnrZsNwGNrbWbSvVgWzVSbgv
mBBFBFQFBhSHggVnmvfW
BJFcRLFFBhLpMNcdNCscZNnqld
vqwQGZNSwNQHQQZNSwvpwMdlnMfBClZBTzBnTfTJCB
sbcrjscccmPmrtFRrtcsPssmVJBfTCldnJJdVzMlBnBJTBlR
tbDmhtdDrPjbDcrDWSHGqQqvHpWSgNHh
VVWSwCpWTVWWwVbbvPJDwvDtwtMttLtH
nfNLcNsfZNnGggZNNqGlMPPDDrlvGHHrtPJMHP
fhgqfznczcjpVRjFLSLz
pvcBCrPrcPBpTccGjrQhQdwMsqdGQddswqhS
FggLnnFzzNFNmstlShMVwQtsgq
RnbzHmNfRHmmnLzRnLDRZHRrCPJBvCWWpcjvJpwWfjwvrc
HfdzzrGfRrQqrGVnznQvgjcjhhlMTlFjchFMVL
swwWWBPNwPwZbvPMFTLjTlgP
BJBJJDZtSrJqnFFfFJ
lqqMSMBMttLMjtHjqjrdBnSfcpfwCTGbCffwCcwbSfTcJf
gVFhVRZgVzJshFZVTbbFfvpcwCTCfbcG
hRWZzRVVZmsWJVRQsQmqqndQrnqnQLqnQqtBlr
SgPhCGGzczlCDVDWrlTL
jvdvFvjqwfdrNfNDlzLzRW
jzjFHnvdtdnmHZttqmbFdFqFsSBJspcgcSPQpsQPBPgpgmSG
qqmQFmrbbWWrtqTVVrgLJTzzNzrJ
nCjMGncHMJvzmmHmVV
DpjPDGwnmDhbwQqZtqqW
JlTTLLMRqlMlJMJgBLLnnCZCFrrrdTGrjPjGFr
vwVpHVHVwvHmQVsFFPZQrjrrrZPNdn
wtvmtwvpmbwVvssPflSBlRBqLMlLJBzSLb
rtrTtBwTsfjZrnqJQplNTcqqlvQT
sHzdWFzSzmGDDRVGVDGHWVhvcLLpNpqJCQqLhClhlcvqpC
VRbmRmRHGdsnggbPMMftZB
LMhtCSSftfTzdCdMhSCdMsQGQbGnbGQQMQggDNgR
FjFHWJwJjRNvQggwnDsm
plBVRRqWRHVHWFTdTthTLCfzflzh
VjVdrHFWPmTjRGSRGq
DMWMZDncQDcfpQzmTQTSQRGTGqNz
WMnsCZJCffDnfCfvnZCPhwVrHBVrBlVHrhswLh
TCZltglCZWQsMhqRHhsrHC
vbbNBbGBmNLzczNmNjrRVbhqHMsVqwHVRwqH
mzBSmzDLvPDPzcLPvGzWWSnsJstWlSsSlddWZJ
nlFJZTlBbFBVZldFnlZlCQvQrsMQzzsCdCLszvLD
hPwgVqSwmRcgSRmWgSwmsfrLPssLvQQfDPDvfMfD
htSwtWHWVRNtWmwgtnJplnbFpBbNTnBTFN
vnhBfSSvRttPJnlctl
frHVDHFwfDLVzVlJMNTHllJHMNlZ
bGGFFbqVLVVbzrFwGfdgFdwvhpCqmBpRqWpBpQpSSpSQSm
RMBMMZBBmmmhZmPjTZhZRPnNQvwWfcSvDfQWBSfdQSNdDc
LHzlVGHqVGzHGzsbCbqglbJddCcvJNDDvdDCJSQvWfwf
HlzrHHgsqbHsVGHqbsGsbbsqFmmjnTTFmnjmRQRPFTFPZtrj
LSLWRMLrLHqqwCBJqCstsG
vbQfPjndQnbcQfmndRwttBNZRsGdsCBJ
bmcnTfbvvPRRRFcmfhjHgzMrSrSMSLzSWgVhML
cqWNtsdsWdlsnBsDJwZJSzFFBZ
RhfvggPfffbVbfPmpMvRRFrZDFFbzDDZZrHwJDbwzb
QhRgvpTVpPgJVGTWWNcTtqNLtG
nppPsSPtPZtFdSWdvFvSnnPscRjjHRTLLjCmRLTmCCscrRcc
wwGqDqfMrGqlhllqhhNwzGNTjCRTmRLTHzJjzBmmRmjCLc
qrblfrVwGwbhwqghfqVhNMhtWSvFdPdQtQdgtWpvWPQWQv
cLJvcccHNcLDwCdRDvjdDR
ttPChbqhZmtWGCtZQwBdsQPQdwwsddQF
WnqbbgGVZCZnnlWhCVtbtVgMMrJLLJNrNcHMJNJTJNMp
vLvWghFhBWqGsVTV
JdpdmbrBmsQGGlVqdw
CJZMHPMZJHmzCnZHHrMjSvcDLDccNSBCDDFDjj
mDgnmRVmqgCSScsVllCj
HLTTMTHZQjZzTzprTGPwtcdlLcllWllWtCSwld
QMHHPzNrQBQGNHzQqbjnBbBbmbfjbqjb
tgPNgzzsSPhjSgbPztSbpDJZRJDTRLTTpRHpNRHZ
crlfGGFlBGBrBcrnFlrFFFCrLpHHJTcLRJJVJvDHtHZRDDRR
tFFtrdmGffnndmzhbWPgzPdsWQPW
JHhvgvzJhBGSLHhgBBSBHzdBflDfllTqLlwLqflfMcctCcfl
RjWQWrnjpjjdNQmmNNWZWpCZtqtDtMwwwcwtcDqcTDqC
PpNPjQspmWpPWRWnVQQpQsWVvvggJBvBSGGdJVhJSJBFdb
FrPTcrCGbcTCChrwNMRDMRvWRdHvzVRVTR
LJmQSmQfJnssmjsHSRFHSHzdVzSFHV
nQtgssgfstjLnmplttgFLLPPpGBrcrchBhCbhhqwPPCC
qFtZtFzstvvPvqttNrCJFWJRFCJFRRWR
ffBBfjQdmdQBfQfmLVQRPRpNNCgPNNRThdWPrr
fQVQlHnBQjBLjlvDqsvPqHMsctSb
rqhJnTTJqTchnTdhncmmgMVqtSBsBspgBtHLLWsBBWpWBHSH
bPldNljGZjNCbFCbwwGDWtBDDtsDtLwt
NjvlvvzQFFQhQqdQnMTM
DJHGghhFhHgsGgThrtrQWBPPJWWCzzzP
lTpffNTdZfrcwlCwCrWz
dmvdvffSSpjTLjFhFMRRbnRbjj
LfSqfmvfWPBPdljNNFVFzVJLNjJz
QZQnQcpMhwhZchQnwbvCCDNDCNpzpFsJpsRsRj
rchgQnvHHhQgvnwHGTffdmdTddTGfWHW
SzZGtmTjgzQCpJwpVqrVzz
NWddPllPDvdbccgcHJLCpClFLLVpFLLVLV
bbdRRWDNdPfgfWPWhdccNddRmBQTSGTTTZnmBQZjmsmnhGst
LgvFffmfVFczCWWmWCSh
MbwbTBDwbZtwBDMhSCGhscWSwVCsSw
QMtdQbqtbZTjVbMtZDMgffnFnJpFvrvFprgvgq
pztdqqzCrpvFqpJQwCvWBRGRWLWcWNBsNNQcNR
HdbjSbVhfhcRscRmNm
MDPffbjbjgFgzCZdFdgt
BmDQZbmmfbmbvhvhbgCsCl
GqVqMHwpGTLHLzwqJlCgsgShhvGvJgGS
LTpzpLFprpfmNrBBlfQP
RjRhBqZbwBbjcwgjPmRtZjZfWFfFznWQNVzQFQQnFzWmMN
vpTPDCdpPSpTSSMzNHzMvFQNNWNM
PDCpLGlGPdrlqRqbqbBhRLqR
PmHZWmJzzzppHfHdHfddDMDLhRbMRgRMNNnPgNMM
TCwBCSSjwqwVqQldTSQTtjVhtbbhbgLLbLLbMggMbDRttc
QBrwFlqCfdzHdvzF
GvgGvgfvlzlHGQWRjGMpjZLjZpGW
DVsqJtnDsJTsTqjpLTdcmWWLpTMp
NNqVhsPrrhqnJNnJNzgBvvjHCCPSjCvQQQ
pqnswpqrrtqrnMsMPMqzVfgGzHBVGVftfBGzGG
QWFQhhmDhJDmJJhhJLcTcfHVvTlTFTfVvgzG
ZDZLddWWSgDCggChRSMPspMjpnqjMPjj
MGwMFLFfssfffcGcDrnCllZtnHQCnDCZWD
dbTvTThtvVVVNWVHClWQzzlQ
TjbgBqTBvBvjRvbqvRmPGMcwSPJPfstSsfMBMf
VtCjjqgwvhCCQdSPJJdGnwwLTT
brrBsmNWlzBpSDcpSWLcWD
SSFsrrrBrCqHVVQFjj
LQQNLgvNDnNPHPDQjtGjnmjttBjVhSmJ
sbWfsMFwdCpdCdwWJVVSltVJlLSlLSft
TFcdMTbpdbwdwgTDQLgDNNrTNz
gfgSsnmnWnhhctcJ
ljjMfwwRTNbRqNlzVzjbtDvPvchvPCccChtJtPVW
GjwpwMpbjMbRMNwqzwpQgQQBfdHfSFrBmQBg
FmcmmTTMdPTGHjtGGnctcN
DgqzTqCgDgpZTrqhSbSpzZfpnHjHlnbtbHBGnGjtQHnlNGWt
zppLhfZTfDqsLMPdMVRwwM
RtsMZJSFRWbRsJbFnFzVBpBqgdRdGzGBpDDj
cTmvrlMQLHLllrhwlmfdQqBpdVpDqGdVpjVzBq
wvTfcHhhmHlhTNLFCnFnNnFnFnMFZJ
grjsjJhhNscgJFgPBnbHwLsRHzHfRLbH
ldMMSSvqtSMGmSSMqLRnlRwbrLlRLRRWwL
VtvDdTGGGCvMDMDTvdjhQjZppPNrJVpZPVFg
wctlscwwBTDnJcLNLHDN
bhhMnhqjzFRjjjPdNDDSvLdJ
MWzMzbrZZZmWQzhWbMhwlspstmnswswllBCgpG
rzmddBcmgFjRzSHHDR
vqpgbnGpqwgbpHtbtRjHTjTfFH
WWqCwvCqCJvCJvwpqvMvnvJMdPgZQQdZcWhBBBrPlLlmdQdm
ZdHTtNPNPSRBbFjjTTsr
WmDhGggmgWWJcZmMhVllzjJCrbjFzbsFFRCj
MMGDmMGGgDGgnWGWpNnvSHStLnwffZtHnw
ddZqRdqjvjZdndlfjwZQQCzmqcHLzzTTHTHzchHTmT
BPVPBBWVLbFFrWgJLpNHcPSHCPSCSCChcCPHTH
VFNbBJrGGJVZGGLwQGnjQL
NllFnzNNnNnNzmrHmDFGLGcccRGjGwHChGwwGh
StMZgPdBgbbBLLvCwCvgGwwj
PsfPtBJMtPZMJPbZVVPPMMDnjDlNlmrnmWnmqzpqmVFm
mGGCppgGWWgmGBzMVzBBBbBS
HnrRdvZvTMtSBtbZ
rHwRrjlrRwrnJrCsCDlLWCqcmCMM
zHhDNmDMNNJHfMNJzjsdvvsvbvjGdCGW
tVwttwwVVFBSFSZqSLjsqLdLCWCvGWcdLs
ZwZgwgpBFGlHgNQmGM
TNqhqvqFNWFrlqFqtDTrhTSTbLfjmjzbwMmMbjzLPDwGLPPP
scVRRQHVQVVHcRHpVgJJCRHMMZGMzCwwLZPZGMMCzLGwZw
dHsnQdHHdnBHspJRsVppFlNTSGGNBWBtTShNTFvG
hdZthMghfbbHCgQgBp
mLjTTjWrTrSCbZsLSbCS
VVPJrjqcWVmrjcmWRWTZTPcWldMNqvhnhMFdvdMhfNdldGNM
sFlsgtZFLFZzSZzpnQrJ
DjRbcjRdBrpRQpMJMJ
jNcfDqqfcDBbmqDFggpFCTpgCNhWWG
LMGGbbpLcpVVbfcpcpdvPVQPmZzJZjqSjSjgZgzqZgzTmm
BrRnBWrtRlhBjmqZCnqJgCSM
FDWWrBHHBBDHhFHttrWFttNpfLppbfcGGsfcGsFfccpcMd
jzHqjHLVqQQlHfzqlbbzqHQscvNsVrvnNZTtvNvvvcrGtv
gJCSRwRpJRtNNSTstnTT
wCMnFgnpCMPnJgpDQbqdQdQQLbzqDHfH
MpqJWmqlNNHmmwwBLLvL
QzFDFfdfQTtSGzTDVMdSFQDwHLBhHLjHjbTbHvLggccwHb
VQfsSDfGftfsdGSDSSQSFssZJCCMlMWWZPWPJMZlRp
lcqqhSsgTMgcqBBZnqZTBJJpdGpGVdRNMJHNGjRJdd
VbfCmPbtttfwwWHdGGrjHPdrRrHN
CffFFmwmDWmtCtvQbSVnTlBSDsqZhVBBSc
gPZTgmwvcnqPzhnW
GJVbDhpjsbWzjfNNNNMj
DFCbrBJsFJpBhbVFJCtvTgmtRTtQQltmwm
BLZgTJPqZzFgCGgCFlFF
ljfcDvNDtHcftNdMCQnCRnhnGjCChG
mVvSdDNDHlmHfNVlSWcSDmtpbpTzppwLPPLPPJLwTwBLPS
FHRzMqvQHvndJnFlNdhZ
fcjWWsjsSmmrgsGgjGcGWsPsnhZddffRdTtNDnZlnDnDThhT
WSPcPsGPSRGCmLcGgpHCzBVqzbQBVpqwwQ
PJzwjrVHzLPrZJHgSsNWbNbmNQtnLSSs
hGhqpTBRRGFFpMpBqGpSNlQQmWlntDbmTQSsml
MpcvMqBRhpFRNCcjwZwPZwJfwjHz
QWJsVCQDbVWbprrWSZWFcmrS
wMwvjRftMLhHfjhdMhRhjtMZrmrmZqBSpBSprvSpTzBTSF
dLNNjhhhVDlNDspN
MNmmtzlQPQmlttlQlHBGFFsHsPnGnFGWgs
CwhhwVZcRVRcCRDWLDFHWWFGss
hwdwdCwCZVSwZcrvhVwCJtbtQtpzmzQHvtpzQmmmpp
CccMdVLJcnCVhCfmjGjlfwwwMwWG
HDSbggDTNbRDHtTgrDpwmnGFfpGgfWfBFmlm
HbDzvQNzHbQLnQddZCcn
jWlqRjWwsqjHHqRDDPMPgpMLpgSMnggC
VQvFfFbdTcfhbcvCpvPrnZgLLpSgLp
PNQVbNTTcbdbfQdbmdVVGfbhBJlHWqGljJqBlqJJlsJJwqqR
WFGnWBTrvtgnjBWsFWggTPlhSfmRSRhZMcSfhZZpRmtZ
CdswHJHNsCbHLVVcZclphwcchfphZZ
LdDCLHsHzbNNNQDsJLNGgPPBvFzjggPrPTrrFB
pGFwwLTPjDcSCPpSdsqtMRMDdVQdVVQz
JBJjZgWgJHvHJgJJbBhNJvgZzsQVRqzdfQQQMMBszRzRzRfV
nlNZWZlJngbvNjgZhNvHhJvprcTclFCcTPSlTCcSpFcLrG
PdHJVCbSJmSVHdLdHbsbsqRwnlDWhZnZccWqDwqDVw
NvMFlGrQTvgpggFNwZhwWWhhqRWRhTqz
gMjvtMpNMrfFrvlffgmdjLLjCmmLHBddLJBS
zNrlzhJGdlHGHplCJQQVbLhRFRbccDSbVDLqRb
WwmwnWjvjmjZPPFFFRDZqVbqqJBS
tmjMJstnWnjvnsTnQMfrQMldrGlCrGfl
MqWfZlpjMPBgffgPNNQnVnnqRsNVLVmR
TcwGCTSvthpzCCTNVnsQVSnRnRQnNn
TbrpDvvCvCwTGDzvzhpzDzljHBZbHWZgHPZJZjJJHfPf
DWNNQQHRpsRWDQPQqHqqgJBCsjjsFFFngBzgjJzl
tMhMwTrTDLMdmMLtMMrbmVbZhJJnnFCCjnlJjjjjBzFBgZ
ttTtDmbfqWcWfqPp
QhvTQqggFsmvjsFTmqZrzzwZrHnwpnplpZ
WCJVGCSLtDPPtHDbHDbdpnrMnMrrpwlZrwpznLpl
VVJbbVfStVHJJVtGmvsfjvssFFTvvsQj
pBCqCqhWjpnWCnffJDjfWzJBZdcvwcPdvJvJcgcrdGdvggrv
tlhbHbmNTbQgbGRvbZGrcg
tVFLQNVlmTmQLQhpzMCBzCpzjjFMnz
qhWHwNqLHrLJjqgHddFchMdnnGnRhMcR
pTzTPVfZQPffNVtVVZfptRGsRbbbbcDsMMZsMZMdRn
CfzPVzCfPBzPBqvWqgBwjNLjjS";
        #endregion
        #region Day4
        public const string Day4 = @"94-97,31-95
7-8,11-95
25-96,3-96
6-17,5-16
35-48,18-49
5-6,5-98
77-78,63-79
56-56,28-56
84-85,22-85
35-62,34-74
9-89,88-88
20-47,11-20
3-50,1-4
49-60,52-61
7-55,54-54
28-80,81-99
8-55,35-55
5-24,5-70
58-81,59-98
3-3,4-4
7-37,6-38
95-98,1-95
51-90,43-50
17-99,16-96
3-27,4-28
38-67,20-68
20-48,19-47
18-99,17-98
1-94,2-2
85-93,8-93
42-52,53-58
24-46,46-49
27-87,86-87
76-76,51-77
3-24,2-88
20-96,48-95
21-48,22-49
9-9,8-65
12-98,98-98
34-35,35-86
15-18,17-86
2-21,1-22
45-97,10-44
13-93,5-94
18-38,37-37
35-36,35-59
6-79,5-78
36-36,35-35
3-4,3-99
41-74,41-75
33-91,4-89
15-99,15-16
15-81,16-81
88-93,87-93
37-97,38-98
18-80,80-80
6-32,7-32
67-93,68-92
2-67,67-79
24-77,23-48
48-95,49-94
47-66,48-67
62-90,5-73
87-89,14-88
43-91,26-94
2-79,1-98
64-97,64-96
8-10,9-9
41-53,41-53
44-53,19-53
40-41,4-41
48-88,47-49
26-96,8-95
20-31,4-25
25-51,26-54
88-90,89-89
35-69,17-21
7-37,6-14
26-99,27-98
84-84,81-91
32-45,44-84
97-98,50-98
5-97,2-4
23-81,22-24
75-76,5-75
24-59,34-59
31-89,88-88
1-2,1-46
58-58,55-58
30-55,29-30
7-88,87-88
35-99,35-89
31-38,30-37
33-73,34-34
13-35,12-61
2-93,17-98
6-96,7-21
43-45,3-44
21-63,20-62
91-91,72-92
95-96,30-96
41-88,30-86
59-68,58-69
19-44,11-18
40-91,2-91
78-78,17-79
1-3,2-7
29-98,29-99
61-78,77-77
74-75,6-75
20-98,19-93
51-63,2-63
1-73,2-74
4-70,4-59
51-74,50-75
86-94,11-69
27-71,42-95
61-91,61-92
57-58,8-58
16-47,25-48
8-43,4-90
5-97,1-11
46-78,50-61
5-46,5-62
25-99,26-82
12-40,20-36
20-44,20-47
96-99,4-97
9-97,97-97
5-10,11-15
3-75,1-4
24-57,23-46
79-97,29-97
37-50,38-59
5-85,6-84
22-82,2-33
9-11,10-90
36-62,37-61
32-49,48-60
74-81,75-80
36-71,35-72
36-92,35-91
88-88,34-87
14-92,13-15
84-97,26-99
65-66,49-66
35-91,34-90
33-33,11-33
6-61,7-62
3-92,17-91
2-71,1-72
39-61,38-39
1-96,2-97
53-90,13-91
51-53,52-93
2-81,1-81
22-97,23-93
63-63,62-76
6-76,7-88
76-94,76-95
24-26,25-65
1-68,2-67
6-98,6-98
12-61,11-60
5-93,6-92
29-61,29-61
11-11,10-73
10-85,11-11
4-98,3-99
22-41,22-76
39-92,56-91
6-91,3-95
40-56,41-57
32-86,13-86
97-97,97-98
66-72,46-73
25-74,74-98
11-85,11-72
39-42,9-53
32-74,37-84
97-98,21-98
39-71,32-38
9-96,95-95
17-25,31-75
96-97,51-95
9-71,71-72
31-32,26-32
14-25,10-13
37-37,38-38
2-13,3-3
38-77,39-78
51-73,72-72
97-99,3-98
59-79,78-78
5-94,4-26
16-97,16-96
88-97,97-98
50-97,50-68
2-87,2-87
5-90,9-30
51-55,53-54
87-87,87-87
39-81,40-82
51-92,4-92
13-78,17-72
41-90,42-91
43-50,22-43
84-86,62-85
69-98,85-98
2-49,4-43
5-96,4-95
11-89,3-10
24-81,25-81
27-85,39-84
33-47,34-39
18-43,19-42
39-45,40-46
26-29,26-31
4-35,36-81
31-86,32-94
9-92,9-91
8-55,8-56
22-48,21-43
25-67,25-72
94-95,53-94
12-40,11-93
58-63,57-64
44-95,94-96
7-87,42-91
7-91,7-8
4-68,32-68
53-73,25-52
9-70,8-69
45-47,46-72
1-1,3-99
46-47,35-46
2-98,1-99
1-13,13-14
31-47,30-46
50-83,82-82
14-14,1-14
3-63,42-62
27-76,26-77
4-98,98-99
16-71,14-72
13-92,13-96
58-92,40-77
11-42,41-86
4-85,2-84
69-78,41-70
27-32,27-33
17-99,8-16
22-86,86-89
88-89,57-88
38-47,39-43
98-98,2-97
8-66,9-67
8-87,3-33
45-46,11-46
79-81,1-80
80-90,82-89
47-47,46-74
50-63,60-62
9-88,8-89
15-91,15-86
12-78,11-79
75-99,13-98
83-84,13-84
18-79,18-29
42-77,42-76
2-94,93-94
4-99,98-98
57-96,60-95
31-70,70-75
4-84,1-3
1-92,7-93
33-76,3-32
5-29,19-29
19-61,62-64
10-70,6-96
1-99,2-98
27-84,28-28
53-53,52-56
72-88,54-99
77-84,74-95
1-2,3-99
2-54,3-53
40-95,3-95
3-43,1-2
8-97,65-97
14-80,14-15
34-62,29-62
3-94,95-98
55-73,56-74
9-60,35-87
32-91,32-92
41-43,42-64
32-37,32-38
9-37,33-35
22-80,22-80
1-85,85-89
23-44,22-43
11-44,10-49
1-91,11-91
23-56,4-60
69-98,38-69
55-56,55-68
8-68,5-69
52-62,52-53
43-77,42-76
4-9,8-8
47-69,68-88
18-75,19-74
46-71,45-70
65-73,68-72
29-90,30-89
31-71,30-70
11-21,13-24
69-89,70-70
9-70,68-70
49-71,72-72
95-95,95-95
11-95,10-96
13-97,13-97
17-97,16-96
22-67,59-66
24-96,25-99
11-45,44-49
33-98,32-96
4-84,4-83
88-91,89-90
37-42,37-38
25-43,9-43
48-78,42-79
7-32,8-8
9-98,10-99
4-85,1-5
82-98,20-83
67-74,68-75
5-98,6-97
76-80,80-81
28-79,27-79
28-57,56-57
88-94,20-88
7-96,95-99
1-61,5-62
97-98,3-97
82-98,19-81
72-90,73-89
44-96,45-45
35-93,39-94
10-89,6-17
22-56,1-21
35-90,89-90
95-95,10-96
16-62,23-62
1-94,1-95
25-27,13-26
9-94,20-77
19-95,18-94
18-19,18-95
6-86,2-5
97-98,7-97
23-72,94-99
12-12,11-13
8-67,9-66
84-96,81-85
97-99,4-96
45-46,14-46
53-60,53-61
59-90,90-91
57-79,79-86
32-78,77-78
64-78,78-78
27-86,86-86
37-58,23-55
5-95,74-93
4-68,56-68
13-37,2-6
80-95,7-80
3-5,4-97
1-67,3-14
55-65,20-55
81-82,81-81
24-82,24-81
30-36,29-37
67-75,11-84
12-99,18-97
61-88,88-94
21-21,20-40
2-92,1-93
51-51,50-99
72-81,69-80
96-98,95-99
39-98,38-97
13-87,12-71
25-93,50-92
15-98,15-33
87-91,86-93
3-98,5-99
8-76,58-77
64-96,50-95
25-60,24-61
69-81,28-70
95-97,14-94
23-79,22-80
45-55,44-45
51-98,52-80
73-96,14-95
35-89,36-88
54-97,55-83
70-87,71-86
81-82,13-82
11-67,11-57
84-84,61-85
9-73,9-74
8-48,7-49
1-90,89-90
3-64,1-2
5-75,5-76
1-1,1-93
82-91,90-92
76-78,64-77
8-64,7-64
9-54,10-55
14-33,13-18
21-22,20-23
7-9,8-62
19-96,20-95
57-66,57-58
78-80,11-79
83-85,60-86
78-78,64-79
4-68,3-54
21-72,41-52
66-89,65-66
15-23,24-92
37-72,58-94
62-73,2-87
94-94,18-95
3-73,4-74
14-97,96-98
5-6,5-89
8-74,87-96
26-81,25-82
33-75,3-74
18-79,39-80
14-79,15-80
30-73,29-31
9-77,23-84
2-55,39-64
31-98,30-91
41-53,42-52
16-84,17-92
21-81,20-22
40-77,39-76
25-31,30-73
95-96,59-95
20-79,8-80
21-64,21-96
29-40,8-39
98-99,14-98
32-33,32-72
15-80,24-80
68-78,69-79
33-46,34-34
4-67,66-97
22-62,91-98
38-43,39-42
15-99,90-99
18-67,18-68
4-73,1-4
9-71,10-96
52-89,51-53
77-96,27-76
5-99,3-97
28-28,27-79
16-55,51-94
12-95,96-97
28-90,29-91
4-28,27-28
32-93,2-93
3-3,3-80
15-47,16-66
1-2,1-95
64-65,21-64
77-77,45-78
64-99,34-78
62-98,88-98
30-93,2-93
4-99,4-96
17-95,86-95
36-96,83-97
34-75,8-74
20-92,20-90
6-6,5-89
68-98,69-78
19-71,19-71
6-49,14-33
8-49,8-50
13-90,14-89
45-54,45-46
69-78,69-94
1-96,2-95
27-95,27-54
7-47,5-73
93-97,25-94
96-96,68-96
3-95,27-97
24-88,16-25
23-41,16-42
66-70,59-71
17-50,16-49
5-85,4-4
19-93,9-52
41-58,53-57
17-96,16-97
51-84,63-97
14-84,13-85
68-96,68-96
20-75,20-75
86-86,6-87
4-53,3-4
11-12,11-12
2-89,88-89
50-76,41-54
65-82,78-81
75-75,75-76
21-54,22-72
17-44,18-45
10-42,10-42
59-70,60-60
27-94,26-51
3-88,89-90
77-77,78-78
30-98,2-97
36-86,17-37
2-2,1-85
41-62,42-63
19-44,81-85
8-99,99-99
77-77,76-76
60-84,60-81
10-76,8-11
66-70,66-72
32-96,33-97
22-52,21-96
16-28,15-27
13-81,82-82
58-58,57-59
45-77,38-60
17-57,17-92
34-71,35-76
69-96,68-98
98-99,91-99
16-90,16-91
71-83,71-89
22-24,23-81
28-32,32-33
59-60,52-60
40-97,70-79
54-55,54-56
28-48,49-67
48-68,68-91
28-83,29-87
39-63,63-63
42-59,60-75
25-38,23-46
71-93,72-97
90-98,29-97
63-85,64-90
34-64,33-65
3-99,2-98
69-97,42-77
73-81,73-80
53-54,19-54
8-94,93-93
56-66,62-65
5-7,6-72
45-93,45-96
5-44,43-45
5-73,40-74
41-71,41-70
50-87,84-88
12-93,67-86
63-93,64-92
11-35,10-34
17-91,17-87
36-89,35-88
17-93,17-92
86-88,45-89
7-55,8-56
12-26,12-55
72-73,10-73
42-96,42-97
13-85,14-84
15-17,16-80
5-45,4-97
11-29,10-12
29-29,28-77
82-83,51-83
91-93,13-93
11-91,7-14
68-68,54-69
82-91,81-92
12-36,11-69
58-71,57-62
6-76,5-77
37-38,38-74
50-94,2-95
88-88,74-89
23-54,22-24
57-66,58-67
98-98,86-87
7-45,13-51
3-82,2-4
6-81,5-7
10-71,11-72
12-81,11-92
25-87,87-94
34-92,40-93
18-18,17-66
91-94,58-94
53-92,8-54
36-41,35-42
1-1,3-80
13-13,12-54
26-27,26-85
19-63,10-78
56-69,57-70
3-98,4-99
75-97,98-99
52-92,99-99
44-56,45-76
18-77,77-78
8-65,9-64
50-61,50-65
89-90,10-90
4-61,8-35
84-88,57-99
16-58,17-57
24-36,35-36
72-92,54-93
18-86,19-85
10-87,87-87
12-92,13-93
87-98,69-98
30-70,31-69
2-99,2-78
5-94,18-97
89-93,88-94
17-58,17-18
40-65,28-41
33-60,32-61
6-98,8-98
13-13,12-86
94-95,61-95
21-62,21-25
12-97,11-91
14-17,18-49
26-97,25-98
7-92,91-92
11-13,12-48
20-31,20-82
2-97,3-98
78-98,99-99
28-69,29-70
29-82,81-82
34-80,59-80
81-83,18-82
84-86,85-88
4-9,9-86
85-86,85-87
99-99,14-98
50-97,49-96
56-89,55-90
37-91,38-90
49-49,48-83
26-92,34-65
18-88,17-89
8-9,9-45
3-3,2-78
29-80,30-79
20-95,20-98
45-56,46-55
26-75,27-76
78-79,10-78
7-10,8-73
25-45,25-46
74-91,73-92
31-76,30-77
38-81,11-53
81-91,87-87
1-3,2-99
59-89,59-89
28-93,8-10
38-98,38-96
94-94,7-94
14-93,13-92
46-46,41-47
25-92,92-93
98-98,9-99
84-85,51-85
6-65,5-64
15-63,16-62
62-75,63-74
34-42,35-55
30-34,33-33
8-8,7-96
63-94,93-94
2-69,2-69
44-44,38-45
74-75,39-75
7-57,7-87
41-59,40-88
12-36,12-35
1-2,1-92
4-64,3-65
28-30,27-27
58-68,59-63
14-61,14-61
14-83,84-85
14-94,15-15
49-49,48-48
52-88,8-91
15-50,14-51
26-55,3-55
36-36,24-37
92-93,40-92
22-98,21-98
22-22,21-23
5-97,99-99
23-75,22-69
11-13,12-85
4-6,16-93
30-32,27-33
3-74,31-73
86-86,35-85
37-40,37-49
58-58,57-74
40-80,19-80
6-42,6-42
84-89,31-83
1-82,4-82
66-99,66-99
19-93,20-82
2-99,1-3
17-71,12-17
58-59,45-59
38-92,18-37
15-20,28-79
42-58,43-57
22-46,46-46
15-26,16-78
96-97,1-97
5-29,6-30
9-23,24-72
17-99,17-98
7-55,6-72
8-81,7-9
21-30,29-44
23-98,51-95
49-60,48-59
66-84,49-84
19-82,18-83
35-85,34-84
31-96,97-98
3-96,1-96
4-89,25-75
36-37,36-96
38-47,31-48
2-16,15-16
66-78,66-77
20-94,19-95
93-94,76-94
23-74,24-75
10-33,21-34
75-93,94-97
7-98,8-97
61-82,2-83
25-38,10-39
4-64,5-63
34-34,28-33
13-52,14-79
8-90,9-43
43-69,44-68
2-3,3-50
69-76,68-75
19-82,19-82
19-89,89-90
3-4,3-82
27-95,26-27
41-70,35-40
18-84,19-85
61-74,61-83
10-99,11-98
26-81,27-48
23-83,23-82
35-91,90-96
54-83,82-82
3-9,2-8
33-97,99-99
23-84,24-90
85-85,6-86
55-63,56-80
49-89,49-88
5-89,2-3
31-40,31-72
25-25,24-53
13-97,14-96
26-28,27-91
91-92,15-92
61-82,60-81
64-65,64-71
5-94,5-80
9-95,9-94
29-83,18-93
1-2,3-34
31-32,31-92
9-45,46-86
20-40,39-39
26-71,70-70
3-13,2-73
42-88,19-91
58-59,27-59
2-81,1-80
6-96,5-95
88-89,32-87
73-90,23-74
18-80,17-66
76-88,76-87
17-83,85-92
15-92,11-14
12-46,44-47
11-28,12-27
11-26,14-26
9-94,8-99
12-85,12-86
43-62,63-68
49-81,85-97
52-77,52-78
9-62,49-62
28-92,29-92
79-80,75-80
3-98,2-99
16-87,17-94
16-25,24-29
11-86,85-87
4-6,5-68
9-69,68-68
12-16,13-17
6-54,5-58
74-97,98-99
22-37,36-97
74-95,78-94
25-90,26-89
37-92,74-91
46-48,15-83
14-89,14-88
8-57,56-57
18-34,17-34
37-46,45-46
3-51,10-51
54-60,49-60
78-78,46-79
77-78,31-77
95-96,10-95
26-53,52-53
17-64,2-88
68-79,67-80
40-77,40-78
28-99,99-99
65-96,43-93
86-95,36-85
14-23,22-23
4-80,46-70
3-92,92-92
30-93,30-30
19-27,19-40
29-80,28-80
34-55,33-56
4-90,4-5
49-84,49-83
14-16,15-91
97-99,1-98
4-83,82-84
24-96,25-97
60-61,1-61
23-80,24-42
14-96,14-67
1-2,1-32
41-75,40-74
15-69,70-74
23-77,22-78
41-91,70-87
72-85,24-86
16-64,37-85
17-72,44-72
15-81,80-82
20-39,68-86
20-97,20-97
73-74,70-74
3-48,1-48
48-98,49-75
72-81,73-82
29-42,29-48
14-87,14-88
14-88,14-87
80-80,48-80
98-99,4-99
90-91,8-90
31-86,30-85
24-98,25-25
30-58,18-58
11-77,76-77
78-94,40-77
14-29,29-99
14-97,13-15
9-89,9-88
92-95,91-94
4-94,5-95
20-89,19-90
70-99,60-92
23-69,22-69
3-23,2-93
22-83,19-20
4-30,1-61
18-20,19-82
49-77,47-77
30-52,5-90
56-87,57-88
24-55,1-49
72-90,40-71
16-79,8-89
19-66,20-74
25-92,24-73
2-2,1-93
29-72,29-79
10-92,11-11
96-99,26-95
14-21,14-21
11-13,12-40
5-9,9-94
18-96,96-97
20-91,91-95
16-34,34-35
53-88,52-53
58-93,17-92
3-97,2-99
12-41,13-95
1-92,26-79
10-97,11-98
42-77,76-78
31-86,32-85
8-64,1-7
64-72,50-72
40-98,39-75
1-97,1-98
60-73,61-74
92-93,5-92
23-35,28-70
17-90,24-88
46-46,6-46
24-96,25-25
54-98,77-97
48-91,47-92
28-99,2-96
83-84,5-84
52-61,52-73
21-38,21-93
9-45,34-37
51-83,67-74
26-26,26-88
41-67,40-70
46-55,43-48
24-74,73-73
43-90,42-89
1-81,82-82
10-98,94-97
54-84,53-83
1-38,12-39
48-92,7-49
74-83,56-85
18-35,18-52
82-84,4-83
98-99,1-99
24-71,25-72
13-81,12-14
22-65,11-23
2-62,13-61
17-40,36-40
8-89,5-93
29-73,28-74
21-96,21-95
67-86,66-87
23-83,82-82
72-74,73-86
96-97,17-97
5-7,6-79
23-54,22-55";
        #endregion
        #region Day5
        public const string Day5 = @"        [M]     [B]             [N]
[T]     [H]     [V] [Q]         [H]
[Q]     [N]     [H] [W] [T]     [Q]
[V]     [P] [F] [Q] [P] [C]     [R]
[C]     [D] [T] [N] [N] [L] [S] [J]
[D] [V] [W] [R] [M] [G] [R] [N] [D]
[S] [F] [Q] [Q] [F] [F] [F] [Z] [S]
[N] [M] [F] [D] [R] [C] [W] [T] [M]
 1   2   3   4   5   6   7   8   9 

move 1 from 8 to 7
move 1 from 2 to 7
move 6 from 9 to 8
move 1 from 9 to 1
move 1 from 9 to 1
move 3 from 3 to 6
move 3 from 3 to 9
move 1 from 9 to 2
move 5 from 7 to 9
move 9 from 1 to 6
move 3 from 4 to 9
move 2 from 9 to 2
move 1 from 4 to 2
move 1 from 3 to 9
move 8 from 9 to 4
move 14 from 6 to 7
move 1 from 3 to 2
move 5 from 4 to 2
move 5 from 5 to 7
move 4 from 2 to 1
move 2 from 4 to 9
move 1 from 4 to 3
move 3 from 5 to 7
move 1 from 8 to 6
move 2 from 8 to 7
move 2 from 1 to 2
move 1 from 9 to 7
move 2 from 1 to 3
move 5 from 6 to 5
move 4 from 5 to 7
move 3 from 8 to 4
move 20 from 7 to 1
move 11 from 7 to 5
move 1 from 6 to 9
move 3 from 9 to 2
move 12 from 1 to 9
move 2 from 8 to 3
move 4 from 2 to 8
move 8 from 2 to 1
move 4 from 8 to 9
move 1 from 2 to 5
move 12 from 9 to 7
move 4 from 4 to 9
move 4 from 9 to 5
move 13 from 5 to 4
move 4 from 4 to 7
move 1 from 7 to 9
move 2 from 9 to 5
move 9 from 1 to 2
move 1 from 8 to 3
move 5 from 4 to 2
move 1 from 3 to 6
move 7 from 2 to 8
move 6 from 1 to 6
move 6 from 8 to 7
move 6 from 2 to 1
move 3 from 9 to 3
move 7 from 3 to 7
move 4 from 4 to 9
move 1 from 8 to 9
move 1 from 3 to 9
move 1 from 2 to 4
move 1 from 9 to 6
move 5 from 1 to 9
move 1 from 4 to 9
move 2 from 9 to 1
move 8 from 6 to 7
move 4 from 9 to 7
move 2 from 5 to 2
move 2 from 1 to 9
move 14 from 7 to 4
move 22 from 7 to 2
move 2 from 7 to 4
move 3 from 7 to 5
move 9 from 4 to 7
move 6 from 2 to 4
move 8 from 4 to 3
move 14 from 2 to 9
move 2 from 3 to 9
move 3 from 2 to 9
move 4 from 4 to 2
move 1 from 4 to 5
move 1 from 1 to 4
move 5 from 7 to 8
move 1 from 1 to 3
move 4 from 5 to 2
move 6 from 3 to 9
move 1 from 3 to 4
move 4 from 8 to 9
move 2 from 4 to 6
move 4 from 5 to 3
move 1 from 7 to 6
move 1 from 8 to 5
move 3 from 3 to 1
move 33 from 9 to 5
move 5 from 2 to 1
move 1 from 3 to 5
move 1 from 7 to 6
move 18 from 5 to 1
move 1 from 2 to 8
move 6 from 5 to 4
move 1 from 8 to 7
move 2 from 4 to 1
move 4 from 1 to 2
move 19 from 1 to 2
move 4 from 6 to 8
move 4 from 1 to 8
move 14 from 2 to 9
move 5 from 2 to 4
move 1 from 8 to 2
move 8 from 2 to 5
move 5 from 8 to 4
move 4 from 9 to 7
move 1 from 8 to 1
move 16 from 5 to 4
move 15 from 4 to 5
move 1 from 9 to 5
move 5 from 7 to 6
move 2 from 7 to 6
move 1 from 1 to 9
move 7 from 6 to 7
move 1 from 8 to 5
move 1 from 1 to 9
move 12 from 5 to 7
move 7 from 5 to 9
move 12 from 7 to 2
move 1 from 7 to 4
move 7 from 4 to 7
move 2 from 9 to 4
move 5 from 4 to 9
move 8 from 2 to 3
move 4 from 2 to 4
move 9 from 4 to 8
move 6 from 3 to 5
move 8 from 7 to 3
move 1 from 4 to 3
move 7 from 8 to 9
move 4 from 5 to 4
move 6 from 3 to 1
move 4 from 3 to 4
move 1 from 3 to 6
move 6 from 4 to 9
move 1 from 6 to 5
move 17 from 9 to 4
move 3 from 7 to 3
move 1 from 7 to 9
move 2 from 5 to 3
move 2 from 1 to 3
move 2 from 8 to 9
move 1 from 5 to 1
move 14 from 4 to 5
move 2 from 3 to 2
move 1 from 7 to 6
move 10 from 9 to 4
move 12 from 9 to 4
move 9 from 4 to 5
move 1 from 2 to 9
move 13 from 5 to 9
move 2 from 5 to 1
move 1 from 2 to 9
move 3 from 4 to 2
move 12 from 4 to 7
move 8 from 5 to 7
move 1 from 1 to 9
move 1 from 6 to 4
move 1 from 5 to 4
move 1 from 4 to 8
move 5 from 3 to 4
move 10 from 9 to 6
move 3 from 6 to 2
move 7 from 6 to 5
move 6 from 5 to 4
move 1 from 8 to 5
move 1 from 1 to 4
move 2 from 7 to 2
move 5 from 4 to 9
move 2 from 5 to 8
move 1 from 1 to 3
move 2 from 1 to 7
move 6 from 7 to 9
move 9 from 9 to 8
move 1 from 1 to 3
move 4 from 2 to 7
move 11 from 7 to 3
move 11 from 8 to 6
move 7 from 3 to 1
move 4 from 7 to 2
move 3 from 2 to 9
move 8 from 1 to 5
move 2 from 7 to 5
move 2 from 2 to 9
move 2 from 3 to 9
move 11 from 4 to 7
move 7 from 9 to 5
move 6 from 6 to 5
move 2 from 2 to 9
move 1 from 2 to 3
move 6 from 9 to 4
move 3 from 9 to 1
move 4 from 3 to 5
move 6 from 7 to 1
move 2 from 6 to 3
move 2 from 9 to 2
move 3 from 3 to 2
move 3 from 6 to 8
move 2 from 7 to 5
move 20 from 5 to 6
move 8 from 5 to 1
move 1 from 5 to 9
move 2 from 8 to 4
move 1 from 8 to 7
move 16 from 1 to 8
move 8 from 8 to 9
move 4 from 2 to 4
move 1 from 1 to 5
move 1 from 5 to 4
move 3 from 8 to 4
move 14 from 4 to 6
move 5 from 8 to 7
move 6 from 7 to 8
move 29 from 6 to 2
move 3 from 9 to 8
move 21 from 2 to 3
move 1 from 8 to 3
move 6 from 9 to 4
move 8 from 3 to 5
move 7 from 8 to 4
move 7 from 3 to 9
move 3 from 7 to 2
move 12 from 4 to 8
move 2 from 3 to 1
move 2 from 9 to 1
move 1 from 6 to 7
move 1 from 7 to 6
move 1 from 6 to 3
move 3 from 1 to 8
move 2 from 4 to 1
move 4 from 6 to 1
move 5 from 2 to 7
move 1 from 1 to 2
move 5 from 1 to 2
move 2 from 8 to 1
move 1 from 4 to 5
move 9 from 8 to 4
move 3 from 7 to 9
move 7 from 5 to 7
move 2 from 5 to 9
move 4 from 9 to 2
move 3 from 3 to 2
move 5 from 2 to 7
move 2 from 8 to 2
move 2 from 7 to 3
move 1 from 8 to 6
move 2 from 1 to 2
move 1 from 6 to 7
move 1 from 8 to 1
move 12 from 7 to 1
move 5 from 2 to 7
move 7 from 4 to 2
move 2 from 4 to 1
move 5 from 3 to 8
move 7 from 1 to 9
move 4 from 7 to 1
move 7 from 1 to 5
move 12 from 9 to 2
move 27 from 2 to 4
move 3 from 8 to 9
move 6 from 2 to 5
move 6 from 1 to 8
move 1 from 7 to 6
move 9 from 5 to 2
move 3 from 9 to 2
move 13 from 4 to 5
move 10 from 2 to 7
move 1 from 9 to 8
move 11 from 5 to 7
move 1 from 8 to 7
move 1 from 2 to 6
move 13 from 4 to 3
move 23 from 7 to 4
move 1 from 6 to 9
move 1 from 2 to 4
move 7 from 3 to 5
move 1 from 9 to 8
move 19 from 4 to 1
move 2 from 4 to 1
move 1 from 7 to 6
move 1 from 4 to 5
move 1 from 5 to 7
move 11 from 5 to 1
move 2 from 5 to 4
move 2 from 6 to 9
move 3 from 8 to 2
move 2 from 8 to 1
move 3 from 2 to 1
move 1 from 9 to 5
move 6 from 1 to 3
move 1 from 9 to 7
move 2 from 7 to 5
move 2 from 8 to 6
move 1 from 3 to 2
move 2 from 8 to 5
move 1 from 2 to 1
move 3 from 4 to 1
move 3 from 5 to 1
move 2 from 5 to 1
move 2 from 6 to 9
move 1 from 9 to 6
move 1 from 4 to 5
move 1 from 9 to 8
move 1 from 8 to 6
move 8 from 1 to 6
move 7 from 1 to 8
move 9 from 1 to 6
move 1 from 5 to 3
move 3 from 8 to 4
move 11 from 3 to 4
move 1 from 3 to 6
move 10 from 6 to 8
move 13 from 1 to 6
move 3 from 4 to 5
move 7 from 8 to 6
move 3 from 8 to 5
move 6 from 5 to 3
move 22 from 6 to 9
move 4 from 3 to 6
move 4 from 9 to 5
move 1 from 1 to 5
move 2 from 3 to 4
move 2 from 1 to 5
move 1 from 9 to 2
move 5 from 8 to 3
move 2 from 9 to 2
move 11 from 6 to 9
move 3 from 2 to 7
move 1 from 6 to 7
move 12 from 9 to 8
move 4 from 7 to 1
move 12 from 4 to 8
move 2 from 4 to 7
move 1 from 1 to 8
move 1 from 5 to 1
move 19 from 8 to 4
move 4 from 5 to 1
move 1 from 7 to 4
move 1 from 7 to 1
move 3 from 3 to 4
move 2 from 8 to 4
move 1 from 5 to 7
move 1 from 7 to 9
move 8 from 1 to 8
move 1 from 1 to 4
move 1 from 3 to 9
move 1 from 3 to 5
move 1 from 5 to 2
move 7 from 8 to 7
move 16 from 4 to 7
move 1 from 7 to 4
move 3 from 8 to 2
move 14 from 7 to 4
move 1 from 5 to 8
move 5 from 7 to 5
move 16 from 4 to 5
move 3 from 5 to 4
move 3 from 2 to 1
move 1 from 7 to 9
move 11 from 4 to 2
move 3 from 8 to 6
move 2 from 1 to 8
move 1 from 4 to 9
move 18 from 5 to 1
move 1 from 8 to 7
move 3 from 7 to 9
move 18 from 9 to 3
move 3 from 6 to 9
move 7 from 1 to 6
move 1 from 8 to 4
move 1 from 4 to 9
move 3 from 6 to 4
move 5 from 9 to 2
move 2 from 4 to 7
move 7 from 2 to 8
move 1 from 7 to 3
move 2 from 6 to 8
move 1 from 9 to 5
move 1 from 6 to 8
move 1 from 4 to 8
move 1 from 5 to 3
move 1 from 7 to 5
move 8 from 8 to 7
move 10 from 2 to 6
move 1 from 9 to 3
move 6 from 6 to 2
move 5 from 6 to 2
move 7 from 2 to 7
move 12 from 1 to 6
move 2 from 2 to 1
move 1 from 2 to 5
move 4 from 7 to 6
move 12 from 3 to 1
move 2 from 7 to 2
move 9 from 3 to 8
move 1 from 2 to 6
move 1 from 5 to 4
move 9 from 6 to 5
move 1 from 7 to 6
move 1 from 4 to 9
move 9 from 6 to 7
move 7 from 8 to 3
move 6 from 3 to 1
move 4 from 8 to 3
move 5 from 3 to 1
move 1 from 9 to 8
move 2 from 8 to 9
move 5 from 5 to 7
move 14 from 7 to 8
move 1 from 9 to 4
move 2 from 2 to 1
move 3 from 5 to 3
move 2 from 3 to 1
move 1 from 4 to 6
move 6 from 8 to 6
move 6 from 8 to 3
move 3 from 6 to 1
move 2 from 8 to 9
move 19 from 1 to 6
move 3 from 9 to 3
move 6 from 3 to 4
move 6 from 6 to 2
move 4 from 3 to 9
move 1 from 7 to 9
move 2 from 5 to 7
move 5 from 9 to 6
move 6 from 7 to 2
move 11 from 2 to 5
move 2 from 7 to 4
move 4 from 4 to 3
move 2 from 4 to 8
move 12 from 1 to 2
move 1 from 8 to 2
move 8 from 5 to 7
move 2 from 4 to 9
move 2 from 7 to 1
move 4 from 2 to 3
move 1 from 8 to 6
move 1 from 1 to 5
move 2 from 9 to 1
move 2 from 7 to 3
move 2 from 5 to 2
move 1 from 5 to 7
move 2 from 7 to 8
move 1 from 5 to 7
move 5 from 3 to 4
move 3 from 1 to 7
move 1 from 2 to 4
move 15 from 6 to 1
move 4 from 4 to 1
move 4 from 2 to 3
move 8 from 3 to 2
move 5 from 2 to 4
move 1 from 8 to 6
move 1 from 8 to 9
move 1 from 3 to 1
move 3 from 7 to 3
move 5 from 7 to 6
move 4 from 2 to 9
move 6 from 2 to 6
move 4 from 9 to 6
move 12 from 1 to 5
move 6 from 4 to 1
move 1 from 3 to 6
move 4 from 5 to 8
move 7 from 5 to 3
move 3 from 8 to 2
move 1 from 2 to 3
move 1 from 9 to 5
move 1 from 4 to 5
move 1 from 8 to 5
move 8 from 6 to 9
move 10 from 1 to 4
move 3 from 6 to 1
move 9 from 3 to 6
move 1 from 3 to 8
move 1 from 2 to 4
move 6 from 9 to 1
move 1 from 1 to 4
move 10 from 1 to 6
move 1 from 8 to 6
move 13 from 6 to 7
move 1 from 2 to 1
move 1 from 9 to 6
move 9 from 7 to 5
move 1 from 9 to 4
move 3 from 7 to 1
move 3 from 5 to 6
move 10 from 4 to 7
move 5 from 6 to 5
move 3 from 4 to 5
move 13 from 6 to 9
move 7 from 5 to 3
move 6 from 3 to 2
move 5 from 6 to 4
move 4 from 2 to 8";
        #endregion
        #region Day6
        public const string Day6 = @"bfdbbngnvnsvshhhrvrbrtbrrhqrqgrrmmdfmmqttptltntrntrnrcrdcrrctctdtwtrwwmlltcltcllmpprvvtbbmbvbsvvqwvvscswsqqgzqqppvzppnddjwddlrdlllmwllfccdfccswwrhhndhdhfdftdfdcdcllcjjbsbgssvlvrrhfrfjfpjffvnfvfwfzftztwwrhwrhwhwddpjjmhmgmsssstzszqzfqzzprpzpnndttphtpphvvcpcjppdtdwwqgwwwnhwnnvhvsvqqtrrbsscwssgwglgwlldjdzjjbsjbsbvvpbvppvfvqvbqbzzwtwbwpbbbcffdgggpnpfptpfphfhfthfthffzrrbzbcblbmmzmhhnvvqvlvwvzvtztgzznbbcqbccwhcwcnwnhndhhgcghhlthllplvppgngrgsswfsfnfjjswstsrtrhthhqzqggdtggzvvjljddqdzzrmrjmjcmjmrrwlldttrhhfjjgbglgjlldrllppnwpnwnndrddtdqdhhpccbgcgzzswzztgzzrwwzzmtztvvrtrgttvddwvwvmwvmmdjdrdtthqhgqhggldgdfdnnzjnjffmrrnprnpnssjrrbrjjrrzvrvhvllfvlvnlvvhlhrhzrzrsrswrssjvjdjfjwwjmjvjjthhnjnmnppsccmlcclfclcbllldwldwdlwddbddmnmrmgrmmtsszgssqjsqscswwzmwmbwwvqqbtbtwwpbbwdbdbhhqmqgqddflfmfnmffbtfbbsdsffspsjpsspzszccrsrstrtjrjppcrrpqqvttsbbjtbjjpbbccmzznvvzzvnvmmwmhmvmsstlssqtssvggtbgttgvtggfhggbcgcmcrmcmhhbttdlttfrfprrvttrtggcpplccqggcwwdjjjplprrbsrbbjsjbbfhbhphtttpffdgdgjddzldzlzplpnplljttdqqlmlllhzhjhccpwcwhwwbbqtqffjpfpfpjptplltbtzbbwwvggpcpprdprpbpvvgzgczzfffzcfzccjffrmrhmrhhchvhddsvswscsnnpfppdrdcrdrgdgmdgmgllhggjwggvqvmmvrrzpprhhqfhfvffvlvnlngnffbbtccfbfhfwhhhhwcwzwjjbffvrffqrrnsnwswrsrvrjvrvprpsptspttbztzfzlfzlflcflclqlplglmlqqvlvvhccmmddqvqzvvmlllvnlnhnfnwnlndnntrrhvvgjjnpnggfqgqdqqzvvclvclvlfvlvvlzlssqffmrfmfmjjczcmmmnttnfnmfnmmmhmggjgdjjqmjjvsslszlzrrpdpcpfcpfpnpssvtsvtvllbttzzljzzhrrnsnddjgdjgjljzzvhvddmdvvdtdmmpmqmnnwcwfwbfwwsvvbpvvgvnvcvdvtvrrcppwbppcqpccwqqzmqmmzczppwbbrzrjzzcrcvrrpttrjjcdjcjfcclscstthqhfqhffdcfdfqdqldddsswbblppdmdnnjvvhwvhvjhvjhjhlhcclrrcqcgcjgcjjtbtctbcbsccfwwltlrlplpfpjphplhhgtghhrppwhhrprwpwhhdqdpdwpwwtccvncvvvrpvphpssfpplcczttltgltldlmlqmmbsszdszznpprsprsprsppsbppjddjhhnrrfsrffmlmglgmlglccddpssdpsddhhfmfsfrfsfnnlggfrgghmgmrmprmprrnvrnnbqnqddhhfwfmfwfmfpfdfzdzppsbpsbpprfrvvwvtwtltvlttrhhgvhhjttmssdggnzzvmvcczmzbzwzttvtpvpcphcctmmhshjsjbssglsglgtltslscchhhsjjpljjdtdsdpppptlpprmppwdppglgmggnddztdzddzppswwmhfbpqzffjqgmsntwsnrwqrqwgpwgrbpbjwrhbcdcvqjnwslsnwhglcsjbwjhswjvzssfqgwbbdgbwfrblfmmlmsndhtlbwzfwsspqlncspqbgbnzshbwpvrmjqjzbcbzzdgssbtqdzffjphqjvrspfrjhpspbwcjwbfhqzsdnjwqjzjtjgnbrdbwqhzffphzppvlmsmppqcfjbjbdsnbwtvthwqcfrtfrwchnmqmhnwfcjtbwqwwvlnpmwlrvzwljrljzqstzglqwbzfdftzltlcbvmmfwcjqglvznztwnvzvftpndqmngqswppsnqhdbgthrddfbcfpflpndrhmcqwvnbfztsvnjjdwqgpmvdwvdftgbtvrwbnvvrwsdfzhwbwdhlpzbcqdzhbfqtpjqcmrpvcsrmcwvgghqrclfzpfgnppzmhvdhvdfrcrnjbdcwbftcqjhhfdsnfnwjzjllzzqftzsjrqnsbpjdcswhhmwwdzmvmqcjtqnczjcvzmmqwzjhjpcczgpbmcvbwmpmvnghlrgcmrrdnmjvmvnhtpfpgwgmdfzvlbclzjzwdqqcvfhhgfzdhzpdvfmwjlzzrpdgzmttmvvcplbwfzqftcgcwcgcpgwvnmlqsplpqwfnhwvqtlwcspqdzshsqnlcpqhpcpbwdhdjsmvtbqdwbcrscqfjcrcjhbjbpzbshpbmlcthmbjfwhzfphgbfqfnfztptzvdnwrpslmdtpmzmpbsszqshwdghrbtvhwzhcmpcgfqggpgzwmhhdrlhlvnpzvwwhzqvgvhrzngttcnqgjjhnblncnqnjzlwnmwnrtvwjtnrbhthncwmzwqdbdgtwrncljddnbhmphgjzfrrgmmcwfwjwjlcrhvcdtvsrvsfhmlgmzsgjchhrfmqslmdgtdtrlbhdffddvbsdbdwlwdcmcmmpvzpdtmbthjdzlpwftptpfsggmhjfjwvbwljsfhfwtbfwmczwhbmhvzllqtcqqfbrcdqqsrcpfmnswnfzfqghcmcbqwgvzqpwvvmbpddlhgjgzvgmpljznrhqphwcztqzpnhzqdgpwwclmsgpwnwtvtsjsdmcnvmjbqglttrhbzqdbgwnbsqzmsmztndrtmlpszhzgjbbftbsdwwdrlftrbbnrsqshfhdpdrwmztcqzdjlnthnjhppwntmbqdgzpmfmfnccblsdwljqhjfgtlgvpzpjbsndmwzfwrbmdhpnmbchqlwqtbhhhqqbsfnvscjwrzvjdtvbsqwzvfhwbbjgqpzcwqjdrlfmggzmhbcrhtbqdjntbtqdvmvpqflmccfpnbmnmtqbdflsgczpbsqpfphlzqgvwbjlmsgshrhpcljzdvwvdvlqqwchtjmjgtqjhgwtnddmhphwhvwhtrhfbjjjzfgrcqngnnddctzdzlqjlbdwmjqzccwrvctrzgtzqsswggbqdnplclhtdslcvzhppcjjslnshtwjnbrwdprqhdtfqmqpgfgnqtdnnhrnzfrsqhlftpdslgmmvqhvpjqjwpwgtnmgrbhwntdjftfwtjzjtprctbtsjmqmpcbbtrjvsgqgsfjprqmsmdztbhnbgzldqfzgwqwnnccgcfclctrwqmqpgvfglgsmmpjszqnphnzcnvswpsfsrmnsnlqnpmvfdvdtfgzrdmbftdrrrbfsvzfgmnffvjpcpnndrwhtjjrrvnztlfhcvfqjgfrhtbnhmwnrmwdhzmmtvjmsqmghtbtfjwdnvdcqtqjrfhrwscjftmbgjmcsrbpdpttlmvfmnfjhnptqvggnshzqnlqqdpqqsqssppbwpblhgfrwrblpzwvqphpsgfmbpqtqqpjpgnbblzstgcjhqntgpbfwlzzctqbnbvpgwsdsdldqzhvznqcsrrghpwllshqpdlqnqgzfwrnhwsvhftzplspcbqmclplprlthvwjhdndrjblqdgwvgjlbmblbmcnbzwzdlnpnhhppvrtngvqqwsttgwlvtcqmtrvpbnvcnfqdtqrsrsmhclmtgbdwwdvhwgfcqpmprcpdhqwftcchbwvstcdqrlwtgbcfqfgzprgvpbbzlqfzbqtcrlzscnqpqwtgzbbbdvsvmhggdr";
        #endregion
        #region Day7
        public const string Day7 = @"$ cd /
$ ls
dir fpljqj
171526 ghtzhjwf.nls
dir gsdsbld
dir hbmjtb
296801 mjfjqw.ccv
dir nfn
dir qmrsvfvw
102565 qqjnqb.chd
dir svgbqd
$ cd fpljqj
$ ls
153563 ghtzhjwf.nls
243252 gsvjgj.jsm
154134 hghnrbqg.rzb
$ cd ..
$ cd gsdsbld
$ ls
dir npmncvhh
dir qmrsvfvw
dir sqtnlr
dir vzndpc
$ cd npmncvhh
$ ls
81366 dwbgr.ztr
144577 fzjmcq
dir mphhrqf
dir rnmvggfd
276454 zfl.ghv
$ cd mphhrqf
$ ls
dir qlcfs
111207 shmcrf.wlr
dir zwsnwvnv
$ cd qlcfs
$ ls
283904 fpljqj.pdw
83520 hsclcqqt.pff
dir htwl
dir lqjhfdch
5842 mdjzmbc.qtv
dir nqfdhlcg
120167 twgqhvft.cgw
186998 zclhcr
dir zfl
dir zlqgr
$ cd htwl
$ ls
268134 hmwnn.htq
$ cd ..
$ cd lqjhfdch
$ ls
21479 tpdsgf.hgd
$ cd ..
$ cd nqfdhlcg
$ ls
dir dhjfqv
203675 ghtzhjwf.nls
39527 qfwdmzfv.ggd
$ cd dhjfqv
$ ls
135074 dqs.wht
$ cd ..
$ cd ..
$ cd zfl
$ ls
17334 wlsd
$ cd ..
$ cd zlqgr
$ ls
dir crs
dir whrm
dir zfl
$ cd crs
$ ls
220281 szft.bjb
$ cd ..
$ cd whrm
$ ls
279796 pcnl
dir pjzpqs
$ cd pjzpqs
$ ls
dir smz
192921 sqtst.lcz
21397 trst
154861 vtgdsnmv
$ cd smz
$ ls
249693 mjfjqw.ccv
dir tdwqpg
$ cd tdwqpg
$ ls
157907 wjv.rth
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd zfl
$ ls
dir hwlhshtr
$ cd hwlhshtr
$ ls
90468 srrv.jst
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd zwsnwvnv
$ ls
209371 ctmcqlz.nwh
154262 nqngjf
$ cd ..
$ cd ..
$ cd rnmvggfd
$ ls
dir czzrdvc
203540 dnwtwzd
dir fcsjqg
dir fwdprwpq
74582 qlnqwnzp.ttz
dir tvglfb
$ cd czzrdvc
$ ls
dir blplbjpw
$ cd blplbjpw
$ ls
2835 zfl.zvw
$ cd ..
$ cd ..
$ cd fcsjqg
$ ls
81548 ghtzhjwf.nls
$ cd ..
$ cd fwdprwpq
$ ls
11156 gsvjgj.jsm
75010 rgscvjq.zlw
122327 szft.bjb
dir zfl
268883 zpgcwvjf
$ cd zfl
$ ls
dir sphpbjt
$ cd sphpbjt
$ ls
31414 qfwdmzfv.ggd
$ cd ..
$ cd ..
$ cd ..
$ cd tvglfb
$ ls
118050 gsvjgj.jsm
265116 sdmldsd.hhm
$ cd ..
$ cd ..
$ cd ..
$ cd qmrsvfvw
$ ls
dir fpljqj
203965 szft.bjb
dir zcgfg
$ cd fpljqj
$ ls
dir gqvmv
$ cd gqvmv
$ ls
175614 mjfjqw.ccv
$ cd ..
$ cd ..
$ cd zcgfg
$ ls
110104 ddzcbm.qtb
dir fpglbth
148639 nqfdhlcg.fsz
dir pfjz
166120 wjrmgl
$ cd fpglbth
$ ls
58850 qlggch.tng
$ cd ..
$ cd pfjz
$ ls
197076 wplpj
$ cd ..
$ cd ..
$ cd ..
$ cd sqtnlr
$ ls
189086 gsvjgj.jsm
dir ngr
210016 pmprhlg.rsg
277979 szft.bjb
282202 tfqcnn.hlf
$ cd ngr
$ ls
dir fdhd
dir hwsqqt
dir qmrsvfvw
$ cd fdhd
$ ls
7384 fhhp
dir fpljqj
91732 nqfdhlcg.gwf
69137 ptcrmc.wwr
$ cd fpljqj
$ ls
282109 rtfhcbc.pqj
$ cd ..
$ cd ..
$ cd hwsqqt
$ ls
174820 zvmgv.tcd
$ cd ..
$ cd qmrsvfvw
$ ls
228739 qfwdmzfv.ggd
$ cd ..
$ cd ..
$ cd ..
$ cd vzndpc
$ ls
183360 fpljqj.nbh
$ cd ..
$ cd ..
$ cd hbmjtb
$ ls
219988 hlvjdg
dir lndmtm
107247 rtpvh.srl
dir sgt
dir tgjszvsg
166122 zrshs.phz
dir ztrvv
$ cd lndmtm
$ ls
dir fpljqj
dir hscwh
dir wjv
$ cd fpljqj
$ ls
102717 qmrsvfvw
$ cd ..
$ cd hscwh
$ ls
dir qgz
dir qmrsvfvw
$ cd qgz
$ ls
281901 szft.bjb
$ cd ..
$ cd qmrsvfvw
$ ls
102781 fpljqj.gtv
197014 gsvjgj.jsm
174895 pvz
$ cd ..
$ cd ..
$ cd wjv
$ ls
dir fpljqj
295195 mjfjqw.ccv
214886 qfwdmzfv.ggd
dir qmrsvfvw
72164 vncjvfhh
$ cd fpljqj
$ ls
dir fpljqj
dir fzbppql
dir jpqqr
dir lzq
dir pjjbmllm
dir qmrsvfvw
$ cd fpljqj
$ ls
260943 ghtzhjwf.nls
$ cd ..
$ cd fzbppql
$ ls
29399 wjv
$ cd ..
$ cd jpqqr
$ ls
45275 zcwbrvd
$ cd ..
$ cd lzq
$ ls
180833 szft.bjb
$ cd ..
$ cd pjjbmllm
$ ls
64063 mjfjqw.ccv
183683 vrfd.wlw
$ cd ..
$ cd qmrsvfvw
$ ls
226047 szft.bjb
$ cd ..
$ cd ..
$ cd qmrsvfvw
$ ls
dir bzcfzh
272794 lnzpvhj
dir vsrgqmlt
dir zbthlb
$ cd bzcfzh
$ ls
63095 mjfjqw.ccv
45335 nqfdhlcg
162307 vqqt.vbg
$ cd ..
$ cd vsrgqmlt
$ ls
dir nqfdhlcg
$ cd nqfdhlcg
$ ls
dir wjv
$ cd wjv
$ ls
81528 cslzgjtp.qzg
$ cd ..
$ cd ..
$ cd ..
$ cd zbthlb
$ ls
dir hjp
dir twfw
dir zfl
$ cd hjp
$ ls
20745 pvjwrzsl.pmg
$ cd ..
$ cd twfw
$ ls
dir csmmbjhp
$ cd csmmbjhp
$ ls
165998 nlsd
109132 vbjlnqt.lsd
$ cd ..
$ cd ..
$ cd zfl
$ ls
227633 jcs.vhj
dir tvfhvbp
$ cd tvfhvbp
$ ls
116169 lgv
175862 qfwdmzfv.ggd
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd sgt
$ ls
151135 nqfdhlcg
226449 nqfdhlcg.sqp
148179 wjv.fgc
$ cd ..
$ cd tgjszvsg
$ ls
98354 szft.bjb
$ cd ..
$ cd ztrvv
$ ls
163992 blmmm.gcf
dir fghl
dir fpljqj
226325 nqfdhlcg
dir qmrsvfvw
284965 vhbffmcg.fwt
$ cd fghl
$ ls
dir lgpwpmzp
dir sqjqg
$ cd lgpwpmzp
$ ls
dir ctr
dir nqfdhlcg
279439 zfl.npd
$ cd ctr
$ ls
64805 jfflsd.gbc
163058 zbvpc.znm
$ cd ..
$ cd nqfdhlcg
$ ls
40180 jsqtwpt.qtq
87408 rmpbprz.lwr
$ cd ..
$ cd ..
$ cd sqjqg
$ ls
140444 bsglv
214121 crzdv.dcc
$ cd ..
$ cd ..
$ cd fpljqj
$ ls
56575 gqw.dzr
293957 gsvjgj.jsm
272507 jvd
dir tgfvcpp
178972 vndshbth.mzw
dir zwtz
$ cd tgfvcpp
$ ls
dir bhq
$ cd bhq
$ ls
111454 gvq
$ cd ..
$ cd ..
$ cd zwtz
$ ls
39290 nqfdhlcg
140517 qfwdmzfv.ggd
dir tcnv
177429 zlzsq.fph
$ cd tcnv
$ ls
286997 fpljqj.phd
$ cd ..
$ cd ..
$ cd ..
$ cd qmrsvfvw
$ ls
252862 jbznh
$ cd ..
$ cd ..
$ cd ..
$ cd nfn
$ ls
dir fqw
dir mpz
dir qmrsvfvw
dir zfl
$ cd fqw
$ ls
144372 ghtzhjwf.nls
100013 mqwwjbvz.scd
95547 vspwhq.dwn
$ cd ..
$ cd mpz
$ ls
dir gntjg
dir jfbhz
7835 nqfdhlcg
dir vpgpz
dir zfl
$ cd gntjg
$ ls
dir hdq
dir hvcdpzr
dir lth
27002 mjfjqw.ccv
dir qmrsvfvw
dir scncl
$ cd hdq
$ ls
dir jwhnt
$ cd jwhnt
$ ls
153428 fswqv.jpf
$ cd ..
$ cd ..
$ cd hvcdpzr
$ ls
dir fpljqj
135000 fpljqj.smw
275125 hrqwfjjz.rdj
dir pmcpnqrr
58960 qljhbczf.qfn
222912 szft.bjb
dir wvvzbt
$ cd fpljqj
$ ls
282896 nqfdhlcg.bjm
$ cd ..
$ cd pmcpnqrr
$ ls
dir nwjzld
dir tfdcg
dir vwlbtgnh
$ cd nwjzld
$ ls
74948 wjv.psf
$ cd ..
$ cd tfdcg
$ ls
77925 gsvjgj.jsm
dir lcdfdmlj
dir pthwnf
227063 qfwdmzfv.ggd
293860 qmwr.csp
154426 scwd.mdc
$ cd lcdfdmlj
$ ls
52503 mjfjqw.ccv
$ cd ..
$ cd pthwnf
$ ls
176935 fgcwjjz
$ cd ..
$ cd ..
$ cd vwlbtgnh
$ ls
dir nqfdhlcg
$ cd nqfdhlcg
$ ls
dir lnwtl
$ cd lnwtl
$ ls
252540 cgj.pdg
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd wvvzbt
$ ls
25603 bvhd
24426 qzwgj.bmb
$ cd ..
$ cd ..
$ cd lth
$ ls
dir dmbf
60608 ghtzhjwf.nls
dir ndbcrvw
dir shsgqzn
27467 zfl.tdf
$ cd dmbf
$ ls
dir zpggmccr
$ cd zpggmccr
$ ls
238504 hqsgz.jfh
$ cd ..
$ cd ..
$ cd ndbcrvw
$ ls
289441 bwbdc
dir zfl
84967 zhwz
$ cd zfl
$ ls
95245 mjfjqw.ccv
$ cd ..
$ cd ..
$ cd shsgqzn
$ ls
184543 gqrthw.gwf
61456 wzbbsqrp
$ cd ..
$ cd ..
$ cd qmrsvfvw
$ ls
dir bql
247487 szvbjdjl
58312 wjv
241150 wjv.ltm
$ cd bql
$ ls
93199 fpljqj
$ cd ..
$ cd ..
$ cd scncl
$ ls
13092 clgmqlfl
dir dcldv
dir fsrznscl
21910 nqfdhlcg.lld
dir prcgb
$ cd dcldv
$ ls
271970 nqfdhlcg.dgv
$ cd ..
$ cd fsrznscl
$ ls
dir bcdrv
$ cd bcdrv
$ ls
96252 fpljqj.cdr
154325 tvf.vhv
$ cd ..
$ cd ..
$ cd prcgb
$ ls
69766 lnsvgqq.psj
$ cd ..
$ cd ..
$ cd ..
$ cd jfbhz
$ ls
286498 ssbmgts
$ cd ..
$ cd vpgpz
$ ls
63751 gsvjgj.jsm
220526 vvlvcs.dpc
$ cd ..
$ cd zfl
$ ls
dir fpljqj
182996 ghtzhjwf.nls
dir jcffb
dir jzl
dir nzlv
6752 snwmlr.glp
$ cd fpljqj
$ ls
dir btsdth
dir fwdw
dir nqfdhlcg
dir qmrsvfvw
203470 svsvcgj
$ cd btsdth
$ ls
176953 szft.bjb
$ cd ..
$ cd fwdw
$ ls
95939 crffczjt.gsq
dir mbgzf
dir rqdnjfdq
296397 zfl.fjb
$ cd mbgzf
$ ls
179220 mjfjqw.ccv
$ cd ..
$ cd rqdnjfdq
$ ls
204152 qmrsvfvw
$ cd ..
$ cd ..
$ cd nqfdhlcg
$ ls
194439 gwc.wdp
167934 qfwdmzfv.ggd
151571 sczw
$ cd ..
$ cd qmrsvfvw
$ ls
dir dwc
103919 gfzgg
6816 shpch.chl
$ cd dwc
$ ls
17813 gsvjgj.jsm
80522 hbhlv.pqh
dir htpt
dir hwg
dir nslrrrfg
dir psgw
231148 sdfvzdwm.wlz
102460 szft.bjb
dir wjlfgt
$ cd htpt
$ ls
162107 wjv
$ cd ..
$ cd hwg
$ ls
dir gslvrbt
dir qmrsvfvw
$ cd gslvrbt
$ ls
dir fjwn
107757 gsvjgj.jsm
$ cd fjwn
$ ls
268653 qptczjlq.prv
$ cd ..
$ cd ..
$ cd qmrsvfvw
$ ls
10557 nqfdhlcg
$ cd ..
$ cd ..
$ cd nslrrrfg
$ ls
112961 gsvjgj.jsm
dir hjgbgq
dir jctqdpq
dir qgfb
dir zfl
$ cd hjgbgq
$ ls
124947 mjfjqw.ccv
$ cd ..
$ cd jctqdpq
$ ls
203489 vgfhrl
$ cd ..
$ cd qgfb
$ ls
33980 nqfdhlcg.pqs
$ cd ..
$ cd zfl
$ ls
193098 gsvjgj.jsm
dir vmzghf
26070 zfnppjsz
$ cd vmzghf
$ ls
235035 szft.bjb
$ cd ..
$ cd ..
$ cd ..
$ cd psgw
$ ls
55808 gsvjgj.jsm
214300 wjv
$ cd ..
$ cd wjlfgt
$ ls
201399 qfwdmzfv.ggd
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd jcffb
$ ls
81815 szft.bjb
$ cd ..
$ cd jzl
$ ls
155651 gsvjgj.jsm
dir shrf
$ cd shrf
$ ls
57545 fpljqj.pcb
$ cd ..
$ cd ..
$ cd nzlv
$ ls
115992 bmmnj.ghw
100862 ghtzhjwf.nls
dir qwjpjw
dir rhbtbjp
dir rlmzs
60695 szft.bjb
3260 vzgwmrnc
dir wwnnj
17546 zdstndwj.lms
$ cd qwjpjw
$ ls
dir dpwp
dir fzdcjr
173669 gsvjgj.jsm
dir nmnbv
dir nqfdhlcg
dir plzdzdnm
135543 qfwdmzfv.ggd
246217 qmrsvfvw
dir sgpcqqm
141900 wvt.rfz
$ cd dpwp
$ ls
214058 wjv.zqs
94614 zrtbln
$ cd ..
$ cd fzdcjr
$ ls
236058 jcn.fzn
$ cd ..
$ cd nmnbv
$ ls
215145 lllgsbb
$ cd ..
$ cd nqfdhlcg
$ ls
61644 ghtzhjwf.nls
238094 qfwdmzfv.ggd
183057 szft.bjb
17501 wjv.pln
$ cd ..
$ cd plzdzdnm
$ ls
243979 fpljqj.lnj
$ cd ..
$ cd sgpcqqm
$ ls
262759 hjffwcls
100893 mvs.cgz
dir nzhlcl
170443 szft.bjb
dir zfl
$ cd nzhlcl
$ ls
dir wcfl
$ cd wcfl
$ ls
24502 mjfjqw.ccv
145029 zfl.lpp
$ cd ..
$ cd ..
$ cd zfl
$ ls
176653 ghtzhjwf.nls
$ cd ..
$ cd ..
$ cd ..
$ cd rhbtbjp
$ ls
dir nqfdhlcg
232788 pmj.cmm
dir zfvbc
$ cd nqfdhlcg
$ ls
72379 gqpcrtpw.nsm
$ cd ..
$ cd zfvbc
$ ls
19204 dqbs.ddg
$ cd ..
$ cd ..
$ cd rlmzs
$ ls
232862 fpljqj.rps
5558 lmgss.dtf
$ cd ..
$ cd wwnnj
$ ls
260417 cwjsrptm.hlm
216130 gsvjgj.jsm
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd qmrsvfvw
$ ls
dir fpljqj
dir hllbt
dir nqfdhlcg
$ cd fpljqj
$ ls
dir qmrsvfvw
dir tdnp
dir vhtwd
dir wnlzd
dir ztttgd
$ cd qmrsvfvw
$ ls
218325 fpljqj.zhj
220402 qfwdmzfv.ggd
$ cd ..
$ cd tdnp
$ ls
46936 fmgz
dir gdsqdtw
dir tpcbjc
dir zfl
$ cd gdsqdtw
$ ls
128812 cnfpsb.qjr
185390 ghtzhjwf.nls
147220 qfwdmzfv.ggd
$ cd ..
$ cd tpcbjc
$ ls
188075 szft.bjb
243171 zdprcqs.qwf
$ cd ..
$ cd zfl
$ ls
dir nnschfl
dir qmrsvfvw
dir szlbls
109443 wjv
$ cd nnschfl
$ ls
139948 szft.bjb
$ cd ..
$ cd qmrsvfvw
$ ls
dir bdn
dir fpljqj
168508 fpljqj.ljd
dir hwgbwqmm
dir nwhl
224059 qfwdmzfv.ggd
$ cd bdn
$ ls
179118 jdrdjf.ppn
74443 lpp
$ cd ..
$ cd fpljqj
$ ls
125033 mtfgm.pjf
$ cd ..
$ cd hwgbwqmm
$ ls
133673 vrvhgbz.ttb
$ cd ..
$ cd nwhl
$ ls
187017 fpljqj
149238 mjfjqw.ccv
dir mqzrmjr
dir vdjgqfc
dir zfzfbq
$ cd mqzrmjr
$ ls
dir fpljqj
131712 jmnsst.bmv
289722 ppdhjswn
dir qmrsvfvw
30641 zfl.trb
$ cd fpljqj
$ ls
286985 lwmfmsr.tln
253325 mjfjqw.ccv
194077 vgb.glm
38905 wjv.vgs
$ cd ..
$ cd qmrsvfvw
$ ls
87468 nngbnwds.qcn
$ cd ..
$ cd ..
$ cd vdjgqfc
$ ls
122025 rnvwf.mrp
261944 wdwgml
$ cd ..
$ cd zfzfbq
$ ls
dir bwmrf
dir zfl
$ cd bwmrf
$ ls
222502 gsvjgj.jsm
$ cd ..
$ cd zfl
$ ls
10297 ghtzhjwf.nls
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd szlbls
$ ls
10968 bqbclc.nfl
$ cd ..
$ cd ..
$ cd ..
$ cd vhtwd
$ ls
188024 dgz
$ cd ..
$ cd wnlzd
$ ls
201028 gsvjgj.jsm
dir mcnnsv
dir mctpdbs
47879 szft.bjb
dir tjqfts
164406 zpdmdrw
$ cd mcnnsv
$ ls
dir lclgj
dir sjdbnbqw
dir tlj
dir wjv
$ cd lclgj
$ ls
192605 fgpjczr.grp
65758 hhrf.fgg
$ cd ..
$ cd sjdbnbqw
$ ls
89058 ghtzhjwf.nls
191742 rlmwjg.dpl
179479 zswc.snt
$ cd ..
$ cd tlj
$ ls
183447 fpljqj.fgf
$ cd ..
$ cd wjv
$ ls
1517 pbwr
189647 szft.bjb
$ cd ..
$ cd ..
$ cd mctpdbs
$ ls
120327 szft.bjb
$ cd ..
$ cd tjqfts
$ ls
dir crvw
$ cd crvw
$ ls
289523 lcshtlgf.lrv
169176 szft.bjb
$ cd ..
$ cd ..
$ cd ..
$ cd ztttgd
$ ls
247914 sqqv.cvm
$ cd ..
$ cd ..
$ cd hllbt
$ ls
298155 cqnb.fgc
224277 hjf
220312 jhnpv
7421 qmrsvfvw
dir qsg
$ cd qsg
$ ls
dir drm
dir fpljqj
dir wjv
$ cd drm
$ ls
dir fhzr
$ cd fhzr
$ ls
dir nqfdhlcg
$ cd nqfdhlcg
$ ls
125578 nqfdhlcg
$ cd ..
$ cd ..
$ cd ..
$ cd fpljqj
$ ls
dir jmfqmdcm
dir nqfdhlcg
48942 qfwdmzfv.ggd
dir swrdzl
18483 szft.bjb
254012 zjcnz.pls
$ cd jmfqmdcm
$ ls
130015 bvrmp.vwg
157978 gsvjgj.jsm
54571 hmhldqr.ctt
169263 qgccqrqs
261388 szft.bjb
$ cd ..
$ cd nqfdhlcg
$ ls
213466 fpljqj.wbp
31434 jhsb.lbb
144357 qfwdmzfv.ggd
$ cd ..
$ cd swrdzl
$ ls
dir fgmtnt
dir pnmz
280186 qmrsvfvw.mrb
$ cd fgmtnt
$ ls
95823 gsvjgj.jsm
127258 qmrsvfvw
$ cd ..
$ cd pnmz
$ ls
110479 ghtzhjwf.nls
$ cd ..
$ cd ..
$ cd ..
$ cd wjv
$ ls
51754 jpwhctfd
174007 mgqplvv.hlt
45041 mtrfs.bhj
153169 vhjw.vbg
$ cd ..
$ cd ..
$ cd ..
$ cd nqfdhlcg
$ ls
dir htnw
280499 tdwzsgqh.zsh
$ cd htnw
$ ls
203521 ggfpmb.pmz
$ cd ..
$ cd ..
$ cd ..
$ cd zfl
$ ls
36860 mlbcw
dir rgvgqqd
239962 rpv.qhp
64500 zfl.mvw
$ cd rgvgqqd
$ ls
26778 qnhpfr
$ cd ..
$ cd ..
$ cd ..
$ cd qmrsvfvw
$ ls
290013 gsvjgj.jsm
$ cd ..
$ cd svgbqd
$ ls
69927 bjc.vdh";
        #endregion
        #region Day8
        public const string Day8 = @"110120112111001131321041300301301303441234124551121322251330313143000402010402222102132100122022010
102022211221313002214040003422200133214443443344513144525425414312301403121303234303302002320112112
210010213122220022044234043143210343153522554535142243154212251531131301322100210101210220021120002
102121023302220201244401343001244152321314335555225552452235435142424222400201243131033233132300012
000111230312012203122030310412244414125415343124153241254535545413214132223113434142202210123003200
200000202333110340220332420035514312151535342225553245343445434132251555330340100104010231010021300
000002323103342131024320314552214234313253142322213135224452154545325222413001110021303002023031310
020211223330002104422314333323242544314345425524624623312225345451215151441224141424031432102112031
103101102120222144402422344225313233124123456625344345362256253215321432522113143331421132120100111
323123312033323011234312234321331412162655266455234525226643636415153422232353340222233324022023103
302102010103231104044441132544233256465665444435532644546542532466625521313425433000033213032131221
020231124210041333545544341311315526432636224253566324632563435552544111344542232330144044224301321
032311340013040441113353131525356533563224525654653323322635463264233535325132533233343233210321103
110211433302212424335511135336624424425234223326565324542445225233624335452112312135211022041303102
111124343140443224431414436336232562665366645354757336364335622463645336643233511434422112010440232
332111113133304452344152264433434644363334554466666633745462642244256564423355241435445123011101202
212041001314124413323342565246562463265754365376533546656375633352465432352631452521422213210110201
231121044331352412232536333252462352747767367443744343645453437733563646524245534445131312434002221
000011114001522121113465525536522235554447657367534677676467534747352424562636651345445123430444422
033334304024332115123455346233566735767767634767465675363455356554575253256464566344352522033141213
232104033314555435242323344642736544645744654476634353477453745657435672625363234545224112403412131
120214322444251411323625366624675353737563557667374544654646775557435446266363566543313111134124033
420431213235113553443522444573577475576437535755887445777573336654356356342453352533355152125341111
441402443522412252223466345675637773673668856678844544444688663376433636472525446235425532411124020
343034354334135156226245336334436363666545868546856758485678688376545667437424262443423353255414420
123124244144511622465262677356633563444567465567644675487646746665647374747452464344641311512532034
433322532145344235242232563656736576488757586878768645575684668477666766537765632543623523513244332
213110151511356235662327355654455654756568875784778455748488676577566333643645635645655451233332214
003345121531552525654355643375777484887864577548475768857464454867457645347356344645633613543412342
144341423313143463233367776463357775888488554696569776898585585445688455633757454245462455145341222
041335352522646255534575456737456888468655876986569988796754685557655846665544557443552421212535234
132451144543362254545554747665754867474669676786977789998678648488644686337433454364255562144312543
234341414316555353366364656378566558879857989657865665569588659488668574575355746442645622422335334
202414253245424644657654564645857765769556657559776969785867965977744445643663463346623662153445430
404435555145642224557443744775746474875958778557798996887569855678458478784765444355645566231512243
111323452142323233364553556545676465685579577696796877857897758575764558888567476375665222644232123
132241411324435253767444655844476465969587669659669969579568655758855786654844777554345252424451111
011355225336326323565666788448765965956896899698789688689679976655557656685676775343636563551341141
324532513343435576434747566467848797788697778778679768986795989857697547586843744574626356422234523
025253552226644277767467644787578659866696976778997677776777796886865885556664664654342632254142144
412111515464343633554467448477487586685699699866966899667979997559785668464554673674342564523335422
325453123456622467456458577565698868997697898896976789986977766766996546564657335556433346253331551
443144222363225477334738848544585556878688866676867798987777769768679996847488767645453222534434414
045152336266426545434376486866786657589979796887779978786669988699776996875845343547672366323234321
314555456265532573343588556657569867679887986979977779997699787866866687675564676436355636434121152
445345442323243573565467688575898889898676668797778799999986796956956577654878674646555453445143133
323522352553645444343475776677555956978889989987978898997669686789676876578865765536762334443434322
124132344466356576453455544479799986797766679878789999979888697989898879786644655476365333553523421
253352232256243753547464768475589785877777969777777989888779798967769766757444463354743242544232545
212355263526236746355777456546888577776796787999987799887997698979955697764877437435645664234345352
541515242423446765665746486857587658886767979797789888897899876897876987477466435537677656454345122
415253463245534755777485854455889698866876777788988888797979866798885567865478777435454263554612531
145324246665623675634667558875896896788779867877778879798889768678999958466466654474656545643434433
152113365324654757767348847478589979769988679779987878879978688679687997774474635453462534455552311
133543342236535533536758767656656575686666788989978797898786688698675689574477765353746666265432341
123524555235435675543457757787767576777898878898999889879688698858787999486574545347562524646441142
325215122324433564655647458587867579998888767999987978886978696788976857558776854354443543254422254
324125454624625565366477667688778698869669789699687866676667977668956697764775653443436655524155221
055552342656325443675677764655968968796988969679886869878798776955899875486644545473653365563533524
351345212454234244763476658647679675666877666798967989999666978659956577857544765336663454366144533
245415116445222245533766565654659768899566797697787887768888988768655688664487374444636232254524244
055243211362633454734457558647686767969756699869899698878789679785856788575566654653336362442231324
011541534264245234636753846747658898666968977778797689779785599598868657845644376633545422443212514
103423241666546224656756547774858788695878796879779997979789699596968547475663637365632646324422131
001521422324233626363533454454667655765595559887977976957659779656655867558753573467236256411415113
215445145523245263777567547774778575769785869669768668598568667589668684865634676776446426432414212
120245213142363544463455456665875887796578765775985685578858898876647744886346554333565554534241223
120223334554222453364443577666674455587696666588885777877558688884586877554755357424253522251422331
412434441222632645377337643754575548447786897669798676676978996875886778874634674726243426342554152
243122434324223244456643446666865477645688796859779866889895846786855676676767773523535241525445100
013013153155543644364657767776687475447654775865868675797788646747654873647674474226625352211145523
020004113313143535323773555653477485866777665956859976974657685868877443673755736243234223233444224
334235225413326355433333455474455586886886688744586564845648554845657533345674533623336243511341122
302411321345244645653257565574357754764475844457844647868854854887656347466544452623355544154243401
134224435445112366524424744773464778578764788774688668458474578674773453473752322455552322424551344
320242444213235642665366275737554356574674754854777466568846454845336536637536232463221415332542211
120333331225354424254244424447355473556464586554755848457865745337574465736352264345213325453404314
131244311135124114464525454757357547746648566476844577887647736335774757753264424234324525522040010
222112401334143525542626632333656567434474637774546584457673644637336377754446633244133521224033240
100130131545341312443226323436755647755373353676347773775744675747753365456434233261235252230231324
041200231254423444455423346225647736374377363763355463646355467446635542462653323615533211201413244
013032132122244324456446552352644533476445745643375653563653666535335644335656236311514244043030122
234224243205554424441336366242253534663367475334557477345773356755522552325462662144535513203231013
121143310442341353211522643525352333564747357554647535667757563555665553524665525533114314444030122
203111120043424354241535424443446543463556465457566437435536475432363266224642255434411120314142421
020011200422212351432221442525254425435523457354776365646346523466434642665415521434321424123110101
003012312214231531314442515232564545642254332433456466634625432532453544524542514532240301400232230
321310000441000025442315211543656254525343246633442633433532525336435245214115222515214020422110212
311002134032004114423233124421234345454652636563532422664532453655625563535545333423414104014432210
310123002002424212534555541242412426446253665664442532364624236533254132221313121131332303110012333
312233030434203004331145432323135425225626243526224624235624556345311121324211111421204401311113023
131032322241033021023241131255512225164542552663455664246554525324144344121311420304320401312303130
112011211021303414331123332211234144312233346245635653336544644421155521315325403444302041213300201
100201110301442032114010443223425434522351241535643562411534342454231441453323011013031130032123023
112131232312112140144242234513131142534253234114125313125313255515313333252022043002314212222122330
011113131212122444114002223055334423355534243143431114514423114231245444321300320012331211022033212
002212000000110302100021230014455443312425144435152143143442414153352133343121411041331012202310102
210201101233022220342334431121141315524541455453142142455421413551235442221014014113231131231321000
220111011200000221024334041434043215212524255254251231145211234333012044102233302403303110130010001";
        #endregion
        #region Day9
        public const string Day9 = @"L 2
U 1
L 2
R 1
L 1
R 2
U 1
R 1
U 1
D 1
L 2
U 1
L 1
R 1
L 1
U 1
L 1
U 2
D 1
U 2
L 1
U 2
R 1
D 1
U 2
L 1
U 2
D 2
R 1
D 1
L 2
R 2
L 1
D 2
R 2
U 1
D 2
U 1
R 2
D 2
L 2
R 1
D 1
U 2
D 1
L 1
R 2
U 1
D 1
L 1
U 2
R 1
L 2
R 1
U 2
D 2
L 2
D 1
U 2
L 2
R 2
L 2
D 2
L 2
U 1
R 1
L 2
R 1
U 2
L 1
D 2
L 1
R 2
D 1
R 1
L 1
R 2
U 2
L 1
U 2
D 1
L 1
U 1
D 2
U 1
D 1
R 2
U 2
R 1
L 1
R 2
L 2
R 1
L 2
D 2
R 2
L 1
U 2
L 1
R 2
L 1
U 2
D 2
L 2
D 2
R 1
U 2
L 2
D 2
U 1
D 2
R 1
D 1
R 2
L 2
R 1
L 3
R 1
D 2
L 1
D 2
L 2
U 1
D 1
R 2
L 2
R 1
D 1
U 1
R 1
D 1
L 2
R 1
U 2
R 2
D 2
R 2
D 3
U 1
L 3
R 2
L 2
R 3
U 2
D 2
U 2
L 2
U 3
D 1
L 1
D 2
U 3
L 3
D 2
R 1
U 1
L 2
D 2
R 2
U 3
L 2
U 2
D 2
R 2
L 1
D 1
L 2
D 1
L 3
U 2
L 1
U 2
R 3
D 2
U 2
R 3
U 2
L 3
D 1
U 1
D 1
U 2
D 1
L 3
U 2
D 1
R 2
U 2
D 1
R 1
U 3
L 2
D 2
L 3
D 3
L 2
D 2
L 2
D 3
R 3
U 2
L 3
R 3
L 2
R 1
L 2
U 3
R 1
L 3
D 3
R 1
L 1
D 1
R 2
U 3
L 3
D 2
R 3
D 3
L 3
U 3
R 2
L 1
R 1
U 2
L 1
U 2
D 2
L 4
U 1
L 1
R 3
D 1
U 3
D 4
U 3
L 4
D 2
R 1
D 1
L 3
U 3
L 1
R 4
U 4
R 4
U 3
L 4
U 3
L 2
R 2
D 2
U 4
L 2
R 3
L 1
R 4
U 3
D 1
L 4
U 1
L 1
U 4
R 3
U 1
D 4
U 1
D 2
L 1
U 2
R 4
L 3
R 2
D 2
U 3
D 2
U 1
D 3
U 1
R 3
L 3
U 2
D 4
U 1
L 2
R 1
L 4
R 2
D 3
L 1
D 1
U 2
L 4
U 4
L 3
R 2
L 2
D 1
U 4
L 1
R 1
U 3
L 3
D 4
R 2
L 1
R 4
D 1
L 2
D 1
U 2
L 3
U 4
L 1
R 3
L 2
U 1
L 3
U 2
D 3
L 4
D 3
L 1
R 4
D 1
L 4
R 4
U 1
R 2
L 3
D 1
R 4
U 1
L 1
D 3
L 3
U 2
L 1
U 4
D 4
U 2
D 3
R 2
L 2
D 1
R 2
L 1
D 2
U 2
D 4
U 3
R 2
L 4
R 3
D 1
U 5
L 5
R 2
D 3
L 5
D 5
U 2
R 3
L 2
R 4
L 1
U 4
R 5
D 5
U 4
D 2
L 4
R 5
D 4
L 5
U 2
L 1
D 2
R 2
D 1
R 3
U 3
R 1
L 1
R 5
L 2
R 1
L 2
U 5
R 5
D 4
L 2
D 4
R 4
U 4
D 3
U 3
D 1
R 4
D 1
U 3
L 2
U 2
R 1
D 1
R 4
U 1
R 5
L 3
D 4
L 2
D 4
L 2
D 4
U 3
D 4
R 3
U 1
L 3
U 3
R 5
L 1
U 4
R 2
L 5
U 3
D 3
U 3
D 2
R 5
U 5
R 2
U 5
L 5
D 4
U 2
L 2
U 3
D 2
L 3
D 2
U 5
L 3
R 3
U 3
D 5
R 3
U 6
D 4
L 2
D 4
L 4
U 6
R 4
D 4
U 5
D 6
U 4
D 5
R 6
D 2
R 5
D 5
L 2
R 5
U 1
L 6
D 4
L 6
U 3
D 6
R 6
L 3
U 5
L 3
U 6
D 1
R 4
L 1
D 2
R 2
U 4
R 4
D 5
L 5
D 6
R 5
D 1
L 3
U 6
D 3
R 6
D 1
L 6
U 1
R 3
U 1
R 4
U 5
L 1
R 1
U 3
L 6
D 1
L 3
R 2
D 5
U 2
L 6
U 6
L 1
U 6
L 3
U 1
D 2
L 6
R 6
D 4
R 3
U 3
R 4
U 5
L 3
D 5
R 3
L 5
U 1
R 4
L 1
D 4
U 6
L 4
D 6
U 4
L 6
U 3
R 6
L 2
U 5
L 3
D 1
U 2
D 4
U 2
L 2
U 1
L 1
U 5
R 1
U 3
R 5
L 1
R 3
L 2
D 1
R 2
D 3
U 4
D 3
U 4
D 2
R 5
U 1
R 2
D 3
R 2
U 4
D 4
R 4
U 5
D 5
U 1
D 2
L 2
R 6
U 5
D 1
R 2
L 1
U 4
D 7
U 4
R 3
U 7
L 2
R 3
L 4
D 4
U 5
R 2
L 5
R 3
U 7
L 2
D 5
U 2
D 4
L 7
R 7
U 1
D 6
U 4
L 6
R 4
D 4
U 1
D 2
R 1
L 2
U 4
R 4
U 3
D 2
U 5
R 4
U 5
D 7
R 4
U 3
L 3
D 4
L 1
R 5
L 5
R 5
U 1
R 6
D 4
U 6
R 5
D 5
L 4
R 3
U 3
L 5
R 1
L 1
D 6
L 3
D 1
U 3
D 7
L 1
R 5
D 4
L 7
R 3
D 7
L 5
D 2
R 2
U 4
D 3
U 4
D 6
R 2
L 2
D 6
U 7
D 6
U 3
D 3
R 3
L 7
R 7
U 3
R 8
U 6
R 5
D 2
L 4
U 3
L 4
D 4
R 4
U 8
D 4
R 3
D 5
L 4
D 2
U 3
D 4
R 1
U 3
R 5
D 4
R 7
D 5
L 4
U 2
R 5
D 4
U 8
D 4
L 8
U 6
L 3
R 3
D 8
L 2
D 6
R 3
U 8
D 8
U 5
D 1
L 1
U 7
D 5
U 7
R 5
U 2
L 1
D 7
L 3
D 6
L 2
R 6
L 1
R 8
L 2
U 6
L 2
D 7
L 5
U 8
D 1
U 4
D 8
U 5
L 8
R 4
D 6
U 7
L 6
U 1
R 2
D 3
R 5
D 7
L 5
R 1
L 5
D 4
R 3
D 7
R 2
D 7
U 8
R 7
L 7
D 2
R 7
U 6
R 1
U 1
R 8
L 2
D 8
L 7
D 3
L 1
R 1
D 7
R 2
L 3
D 8
L 2
U 5
D 5
R 1
D 4
U 2
D 5
L 1
D 1
R 5
D 8
U 2
D 7
U 3
L 9
D 1
U 2
R 8
U 5
D 3
U 8
R 6
L 5
U 3
L 9
D 1
R 7
U 1
D 4
R 6
D 7
L 8
R 5
U 4
L 5
D 2
R 4
L 9
D 1
U 5
R 1
D 4
R 7
U 8
R 3
U 4
L 9
D 9
R 6
L 2
D 7
U 3
L 6
R 5
U 1
R 1
D 6
L 9
U 2
D 4
L 3
D 7
L 5
R 7
L 4
R 7
L 9
U 8
R 6
L 1
U 7
D 6
R 2
L 7
D 7
R 4
U 5
R 1
L 9
R 2
D 2
U 3
R 8
U 6
L 8
D 3
L 7
R 9
L 5
U 4
R 9
U 3
L 8
R 9
D 3
L 2
R 3
D 8
R 6
D 7
R 6
U 8
L 4
U 7
R 1
L 3
D 8
U 1
L 9
D 5
L 5
U 8
R 9
L 2
U 5
D 2
U 3
L 8
R 9
L 7
R 4
L 7
R 10
U 9
D 8
U 8
R 1
U 2
D 6
U 9
L 4
D 5
U 9
D 8
R 5
U 5
D 3
U 5
R 2
D 1
U 4
L 7
R 6
D 9
L 9
D 4
L 4
D 2
L 3
R 8
L 1
D 8
R 2
U 2
D 3
R 9
L 5
U 3
L 10
U 2
D 7
R 9
L 7
D 4
L 10
R 7
L 4
D 3
R 8
D 1
R 6
L 1
U 1
R 6
U 8
L 5
R 7
D 9
L 1
D 9
R 4
D 5
R 7
D 4
U 10
R 2
L 1
U 9
D 1
U 7
R 10
U 9
R 5
L 3
U 5
R 4
D 6
R 5
L 4
U 2
L 1
D 5
U 7
D 6
R 8
U 8
D 8
R 9
D 7
R 2
U 10
R 6
L 10
R 10
U 8
D 9
R 9
D 4
R 1
L 5
U 2
D 4
R 4
D 2
L 9
U 10
D 3
R 10
L 8
U 8
R 2
L 11
U 6
L 11
U 7
L 8
D 8
L 2
R 7
L 10
R 10
D 5
L 7
D 9
L 7
R 3
U 11
L 1
U 11
R 5
D 2
L 1
D 1
L 9
R 6
U 6
L 8
R 2
D 7
U 3
L 7
D 7
L 1
U 2
L 4
D 9
R 6
D 4
R 2
L 10
R 8
L 10
U 2
R 11
L 11
R 4
U 3
D 11
R 10
D 11
L 1
U 10
R 10
U 1
L 3
U 8
D 6
L 9
R 7
U 1
R 5
L 4
D 5
L 11
D 3
L 7
D 3
U 4
D 6
R 8
U 2
L 4
R 8
L 9
R 10
U 5
L 6
U 8
R 5
U 11
R 5
D 9
R 6
U 4
L 2
R 7
L 5
R 5
U 4
L 3
R 2
L 6
D 7
U 6
D 8
U 11
D 2
U 4
R 4
D 11
L 6
R 6
D 5
U 9
D 1
U 8
D 9
R 8
D 11
U 11
R 2
U 3
R 11
L 6
U 3
R 5
L 12
R 5
L 4
D 11
U 10
R 11
U 8
L 7
R 10
L 11
R 2
L 5
R 12
L 6
R 7
L 12
D 5
L 6
U 9
R 12
U 12
R 7
D 5
R 2
D 7
U 9
R 11
U 3
L 8
U 10
L 4
R 4
D 3
U 2
R 10
U 7
D 7
R 6
U 11
D 2
L 7
R 9
D 12
L 5
U 2
R 3
U 3
R 1
L 7
R 8
D 12
R 6
U 12
R 11
D 12
R 4
D 8
U 6
D 1
R 6
U 2
D 5
U 7
L 6
D 5
R 5
L 6
U 4
D 12
R 11
L 3
R 7
L 5
R 7
U 9
R 7
D 1
R 12
L 5
U 1
R 12
L 6
D 1
R 9
L 5
R 7
D 11
L 9
R 6
U 2
R 6
U 1
R 10
L 11
U 10
R 11
U 6
L 1
D 10
U 9
L 3
U 12
R 4
U 1
D 4
R 3
U 4
D 3
U 13
D 12
U 11
L 8
D 5
R 7
D 5
L 11
U 3
R 12
D 3
R 1
L 8
D 11
L 3
R 12
U 4
R 6
L 10
D 5
L 10
D 13
U 5
L 3
R 10
L 7
R 13
L 10
D 8
L 8
U 8
D 9
R 8
D 2
U 6
D 3
R 8
D 6
R 13
U 10
D 6
L 3
R 4
U 11
R 6
D 4
R 4
U 1
R 11
D 7
R 11
D 3
R 8
L 5
U 9
D 9
U 13
L 2
U 9
L 7
U 10
R 12
U 7
L 6
R 10
L 12
U 6
L 4
D 8
R 2
L 2
R 7
L 9
R 1
D 3
U 7
L 3
R 1
D 3
R 5
U 10
D 13
L 3
D 8
U 4
R 13
D 8
U 3
D 9
L 3
D 9
U 6
L 10
R 8
L 2
U 4
L 8
D 1
U 13
L 5
U 3
D 9
L 8
U 10
L 4
R 13
D 9
R 6
L 5
U 13
D 11
R 3
U 8
D 1
U 5
L 1
D 6
R 1
U 7
D 5
R 14
U 7
D 13
L 9
U 13
L 7
R 14
L 2
U 10
R 9
L 14
R 8
L 5
U 7
R 14
U 8
D 9
R 14
L 9
D 7
R 1
D 1
L 13
R 13
D 4
R 11
D 2
R 3
U 3
R 11
L 1
R 8
U 9
L 2
R 12
U 3
L 14
D 3
U 8
R 13
L 2
R 8
D 8
U 14
R 6
U 1
L 3
D 9
U 6
R 10
L 4
D 8
L 10
U 11
D 9
U 13
L 11
R 8
L 7
R 7
U 8
D 7
L 9
R 11
L 6
R 9
U 12
L 9
R 3
U 1
D 11
U 1
R 10
D 9
L 11
D 4
U 6
L 12
D 11
R 2
D 2
L 14
R 6
D 5
L 12
R 6
D 6
R 13
U 5
D 12
U 8
D 11
R 6
L 11
U 4
L 11
U 12
L 7
D 7
R 2
U 11
L 4
U 9
R 6
D 4
U 7
R 1
L 13
D 1
U 7
L 1
R 5
U 10
L 11
D 4
U 15
L 5
D 14
U 8
D 13
R 2
U 13
D 1
R 3
U 2
L 6
D 1
U 9
D 9
U 4
D 5
U 8
D 13
L 4
U 12
L 9
R 9
L 7
U 8
L 7
R 4
L 5
U 6
R 8
U 13
D 7
L 8
R 5
D 6
U 14
L 10
R 14
L 13
U 10
D 6
R 2
U 14
L 9
R 4
U 14
R 7
D 1
U 5
L 5
D 4
L 2
U 11
L 5
D 12
L 1
D 14
L 10
R 14
D 12
L 10
U 2
D 13
L 15
U 1
R 15
D 14
R 2
U 7
L 5
U 15
L 15
D 9
L 1
D 13
U 3
R 15
L 6
D 10
L 4
U 10
R 14
L 8
U 7
D 10
U 1
R 7
L 14
R 5
L 9
D 15
L 14
R 14
L 7
R 6
L 3
D 13
L 5
D 10
R 9
L 2
D 16
U 9
L 14
R 2
D 2
R 1
L 1
U 7
D 12
R 4
U 15
R 7
U 14
R 2
D 3
R 6
L 9
U 8
R 7
L 8
D 6
R 13
D 10
L 9
D 1
U 14
L 8
R 3
L 14
R 2
D 13
L 1
R 15
U 5
D 4
R 9
D 9
L 3
D 12
R 4
U 8
L 6
D 10
L 6
R 12
D 14
U 5
D 13
R 13
U 11
D 10
R 16
L 3
U 10
D 8
L 1
U 8
D 4
L 6
R 12
D 7
L 5
U 11
R 5
D 7
L 2
U 9
L 8
R 14
D 5
R 6
U 10
D 16
U 4
R 11
U 3
R 4
U 5
L 11
R 12
U 9
R 9
D 12
R 8
D 9
L 5
D 5
U 11
L 16
U 2
L 5
R 10
U 13
R 10
L 3
D 3
U 2
L 14
D 15
L 8
D 1
L 10
R 6
L 5
U 6
R 14
U 11
R 16
L 1
R 16
L 10
U 9
D 2
L 2
U 15
L 3
D 11
L 16
U 9
D 17
U 4
D 14
U 4
L 5
R 14
L 2
U 13
D 1
U 6
R 3
U 7
D 12
L 11
U 6
L 5
D 16
R 11
L 2
R 15
D 3
U 11
R 2
D 6
R 16
L 9
R 4
L 8
D 4
L 3
D 15
U 10
D 4
U 8
R 2
U 16
L 9
D 5
R 8
D 11
R 13
U 11
D 2
R 16
D 10
L 11
U 6
L 13
D 10
L 10
R 13
U 5
R 10
D 2
R 2
D 14
L 15
R 15
D 1
L 2
U 17
L 12
R 9
D 10
L 2
D 12
R 8
U 1
L 6
U 14
L 15
U 13
L 15
D 3
U 8
R 14
U 3
L 12
R 5
L 12
R 12
U 6
D 10
U 4
D 11
U 1
D 17
U 5
D 8
U 9
R 9
L 6
R 10
U 1
D 3
R 1
D 4
L 16
D 16
U 3
L 17
D 8
R 15
D 9
R 7
D 8
R 17
L 13
U 16
D 2
L 1
R 3
D 11
R 15
L 10
R 9
U 1
R 11
L 15
U 2
R 12
U 18
R 18
D 4
U 7
D 13
U 18
D 14
U 7
D 2
L 1
R 1
U 4
L 13
R 4
U 13
L 16
D 12
R 4
U 9
D 11
R 4
L 16
D 4
L 8
D 3
R 9
U 15
R 3
L 9
U 2
R 15
L 5
R 3
D 17
U 17
R 11
L 13
U 8
D 11
L 12
U 1
D 5
U 12
D 2
R 13
D 6
R 5
D 10
U 15
R 7
L 4
R 8
D 10
U 17
L 12
U 14
L 9
D 18
R 11
U 13
D 9
L 1
D 9
U 6
R 15
L 1
U 4
D 13
R 18
U 3
L 2
U 18
R 17
L 14
U 12
R 7
L 11
D 3
U 17
D 9
R 13
L 18
D 15
R 16
U 16
L 12
D 16
R 18
L 13
D 8
U 16
D 2
U 17
D 4
L 12
U 3
D 2
R 3
L 14
D 7
L 6
U 5
L 19
R 19
L 7
R 1
D 2
U 11
L 7
U 8
L 4
R 4
L 12
U 7
R 3
U 3
L 2
R 3
D 9
R 16
U 4
R 12
L 10
D 3
U 17
D 6
U 14
D 2
L 19
U 3
R 19
L 11
U 13
R 11
D 14
L 4
D 11
U 9
L 8
U 18
L 17
D 7
U 7
R 19
L 8
D 6
R 7
U 19
D 7
R 7
L 16
R 11
L 2
R 10
U 6
R 2
U 8
L 8
D 3
L 12
D 16
U 1
D 12
L 4
D 16
R 13
L 12
R 11
U 8
L 6
D 6
L 1
U 5
L 3
R 6
U 8
R 5
U 4
D 14
R 7
U 2
L 9
U 8
R 13
U 1
D 15
R 18
D 15
R 14
D 15
R 8
D 16
U 6
L 7
D 10
R 9
L 12
R 11
L 3
R 12
D 8
U 14
L 18";
        #endregion
        #region Day10
        public const string Day10 = @"addx 1
noop
addx 2
noop
addx 3
addx 3
addx 1
addx 5
addx 1
noop
noop
addx 4
noop
noop
addx -9
addx 16
addx -1
noop
addx 5
addx -2
addx 4
addx -35
addx 2
addx 28
noop
addx -23
addx 3
addx -2
addx 2
addx 5
addx -8
addx 19
addx -8
addx 2
addx 5
addx 5
addx -14
addx 12
addx 2
addx 5
addx 2
addx -13
addx -23
noop
addx 1
addx 5
addx -1
addx 2
addx 4
addx -9
addx 10
noop
addx 6
addx -11
addx 12
addx 5
addx -25
addx 30
addx -2
addx 2
addx -5
addx 12
addx -37
noop
noop
noop
addx 24
addx -17
noop
addx 33
addx -32
addx 3
addx 1
noop
addx 6
addx -13
addx 17
noop
noop
noop
addx 12
addx -4
addx -2
addx 2
addx 3
addx 4
addx -35
addx -2
noop
addx 20
addx -13
addx -2
addx 5
addx 2
addx 23
addx -18
addx -2
addx 17
addx -10
addx 17
noop
addx -12
addx 3
addx -2
addx 2
noop
addx 3
addx 2
noop
addx -13
addx -20
noop
addx 1
addx 2
addx 5
addx 2
addx 5
noop
noop
noop
noop
noop
addx 1
addx 2
addx -18
noop
addx 26
addx -1
addx 6
noop
noop
noop
addx 4
addx 1
noop
noop
noop
noop";
        #endregion
        #region Day11
        public const string Day11 = @"Monkey 0:
  Starting items: 63, 57
  Operation: new = old * 11
  Test: divisible by 7
    If true: throw to monkey 6
    If false: throw to monkey 2

Monkey 1:
  Starting items: 82, 66, 87, 78, 77, 92, 83
  Operation: new = old + 1
  Test: divisible by 11
    If true: throw to monkey 5
    If false: throw to monkey 0

Monkey 2:
  Starting items: 97, 53, 53, 85, 58, 54
  Operation: new = old * 7
  Test: divisible by 13
    If true: throw to monkey 4
    If false: throw to monkey 3

Monkey 3:
  Starting items: 50
  Operation: new = old + 3
  Test: divisible by 3
    If true: throw to monkey 1
    If false: throw to monkey 7

Monkey 4:
  Starting items: 64, 69, 52, 65, 73
  Operation: new = old + 6
  Test: divisible by 17
    If true: throw to monkey 3
    If false: throw to monkey 7

Monkey 5:
  Starting items: 57, 91, 65
  Operation: new = old + 5
  Test: divisible by 2
    If true: throw to monkey 0
    If false: throw to monkey 6

Monkey 6:
  Starting items: 67, 91, 84, 78, 60, 69, 99, 83
  Operation: new = old * old
  Test: divisible by 5
    If true: throw to monkey 2
    If false: throw to monkey 4

Monkey 7:
  Starting items: 58, 78, 69, 65
  Operation: new = old + 7
  Test: divisible by 19
    If true: throw to monkey 5
    If false: throw to monkey 1";
        #endregion
        #region Day12
        public const string Day12 = @"abaaacccccccccaaaaaaccccccccccccccccaacccccccccccaacaaaaaaaaaaaaaaaaaccaaaaacccaaaaccccccccccccccccccccccccccccccccccccccccccccccccccccccccaaaaa
abaaacccccccccaaaaaacccccccccccccccaaaaccccccccccaaaaaaaacaaaaaaaaaaaccaaaaaaccaaaacccccccccccccccccccccccccccccccccccccccccccccccccccccccaaaaaa
abaaaccccccccccaaaaacccccccccccccccaaaacccccccccccaaaaacccaaaaaaaaaacccaaaaaacccaaccccccccccccccaaaaacccccccccccccccccccccccccccccccccccccaaaaaa
abccccaaccccccaaaaacccccccccaaaaaccaaaaccccccccccccaaaaacaaaaaaaaacccccaaaaaccccccccccccccccccccaaaaacccccccccccccccccaaaccccaaaccccccccccaaacaa
abcccaaaacccccaaaaacccccccccaaaaacccccccccccccccccaaacaaaaaaaaaacccccccaaaaacccccccccccccccccccaaaaaacccccccccccccccccaaaaccaaaaccccccccccccccaa
abcccaaaaacacccccccccccccccaaaaaaccccccccccccccccccaaccaaaaacaaaaccccccccccccccccccccccccccccccaaaaaaccccccccccccccccccaaaaaaaacccccccccccccccaa
abaaaaaaaaaacccccccccccccccaaaaaaccccccccccccccccccccccaaaacccaaaccccccccccccccccccccccccccccccaaaaaacccccccccccccccciiiiijaaaaccccccccccccccccc
abaaaaaaaaaacccccccccccccccaaaaaacccccccccccccccccccccccccccccaaacccccccccccccccccccccccccccccccaaaccccccccccccccccciiiiiijjjaccccccccaaaccccccc
abccaaaaaaccccccccccccccccccaaaccccccccccccccccccccccccccccccccacccccccccccaacccccccccccccccccccccccccccccccccccccciiiiioijjjjaaccccccaaaaaacccc
abccaaaaaacccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccaaaaaacccccccccccccccccccccccccccccccccccciiinnooojjjjjaaccaaaaaaaacccc
abccaaaaaacccccccccccccccccccccccccccccccccccccaacccccaacccccccccccccccccaaaaaacccccccccccccccccccccccccccaaaccccciiinnnoooojjjjjjkkkaaaaaaacccc
abcaaaaaaaaccccccccccccccccccccccccccccccccccccaaaccaaaaaaccccaaacccccccccaaaacccccccccccccccccccccccccccccaaaaccciiinnnouooojjjjkkkkkaaaaaccccc
abccaccccccccccccccccccaaccccccaccccccccccccaaaaaaaaaaaaaacccaaaacccccccccaaaacccccccccccccccccccccccccccaaaaaacchhinnnttuuooooookkkkkkkaaaccccc
abccccccccccccccccccaacaaaccccaaaaaaaaccccccaaaaaaaacaaaaacccaaaacccccccccaccacccccccccccccccccccccccccccaaaaacchhhhnntttuuuooooppppkkkkcaaacccc
abccccccccaaacccccccaaaaaccccccaaaaaaccccccccaaaaaacaaaaaccccaaaaccccccccccccccccccccccccccccaccccccccccccaaaaahhhhnnntttxuuuooppppppkkkcccccccc
abccccccccaaaacccccccaaaaaaccccaaaaaaccaaacccaaaaaacaaaaaccccccccccccccaaccccccccccccccaaaaaaaacccccccccccaachhhhhnnnntttxxuuuuuuuupppkkkccccccc
abccccccccaaaacccccaaaaaaaacccaaaaaaaacaaacacaaaaaaccccccccccccccccccccaacccccccccccccccaaaaaacccccccccccccchhhhmnnnntttxxxxuuuuuuupppkkcccccccc
abacccccccaaaacccccaaaaacaaccaaaaaaaaaaaaaaaaaaccaacccccccccccccccccaaaaaaaaccccccccccccaaaaaaccccccccccccchhhhmmmntttttxxxxuyyyuvvpppklcccccccc
abacccccccccccccccccacaaaccaaaaaaaaaaaaaaaaaaaccccccccccccccccccccccaaaaaaaacccccccccccaaaaaaaaccccccccccccgghmmmtttttxxxxxxyyyyvvvpplllcccccccc
abaccccccccaacccccccccaaaccaaaaaaaacaaaaaaaaaaccccccccccccccccccccccccaaaaccccccccccccaaaaaaaaaaccccccaccccgggmmmtttxxxxxxxyyyyyvvppplllcccccccc
SbaaaccccccaaacaaaccccccccaaaaaaaaacaaaaaaaaacccccccccccccccccccccccccaaaaacccccccccccaaaaaaaaaaaaacaaaccaagggmmmtttxxxEzzzzyyyvvppplllccccccccc
abaacccccccaaaaaaacccccccaaaaaaacaaccaaaaaaaccccccccccccccaaaccccccccaaaaaacccccccccccacacaaacccaaaaaaacaaagggmmmsssxxxxxyyyyyvvvqqqlllccccccccc
abaccccccccaaaaaaccacccaaaaaaaaacccccccaaaaaaccccccccccccaaaaccccccccaaccaacccccccccccccccaaaccccaaaaaaccaagggmmmssssxxwwyyyyyyvvqqqlllccccccccc
abaccccccaaaaaaaaccaacaaaccaaaaaacccccaaaaaaaccccccccccccaaaaccccccccccaacccccccccccccccccaacccccaaaaaaaaaaggggmmmssssswwyywyyyyvvqqlllccccccccc
abaccccccaaaaaaaaacaaaaacccaaaaaacccccaaacaaaccccccccccccaaaaccccccccaaaaaaccccccccccccaacccccccaaaaaaaaaaaaggggmmmossswwyywwyyvvvqqqllccccccccc
abcccccccaaaaaaaaaacaaaaaacaaccccccccaaacccccccccccccccccccccccccccccaaaaaaccccccccccccaaaaacccaaaaaaaaaaaaaaggggoooosswwywwwwvvvvqqqmlccccccccc
abccccccccccaaacaaaaaaaaaacccccccccccaaacaccccccccccccccccccccccccccccaaaaccccccccccccaaaaaccccaaacaaacccaaacagggfooosswwwwwrvvvvqqqqmmccccccccc
abccccccccccaaacccaaaaaaaacccccccccaacaaaaacccccccccccccccccccccccccccaaaaccccccccccccaaaaaacccccccaaacccaaccccfffooosswwwwrrrrrqqqqqmmccccccccc
abccccccccccaacccccccaaccccccccccccaaaaaaaacccccccccccccaaccccccccccccaccaccccccccccccccaaaacccccccaacccccccccccfffoossrwrrrrrrrqqqqmmmccccccccc
abccaaaccccccccccccccaacccccccccccccaaaaaccccccccccccaacaacccccccaaaaacccccccccccccccccaacccccccccccccccccccccccfffoossrrrrrnnnmqqmmmmmccccccccc
abcaaaaccccccccccccccccccccccccccccccaaaaacccccccccccaaaaacccccccaaaaacccaaaccccccccccccccccccccccccccccccccccccfffooorrrrrnnnnmmmmmmmccccaacccc
abcaaaacccccccccccccccccccccccccccccaaacaaccccacccccccaaaaaaccccaaaaaaccccaaaccacccccccccccccccccccccccccccccccccffoooonnnnnnnnmmmmmmccccaaacccc
abccaaacccccccccccccccccccccaaaaaccccaaccccaaaacccccaaaaaaaaccccaaaaaaccccaaaaaaaccccccccccccccccaccaccccccccccccfffooonnnnnnddddddddcccaaaccccc
abccccccccccccccccccccccccccaaaaaccccccccccaaaaaacccaaaaacaacccaaaaaaaccaaaaaaaacccccccccccccccccaaaaccccccccccccfffeonnnnneddddddddddcaaacccccc
abccccccccccaaaccccccccccccaaaaaacccccccccccaaaacccccacaaacccccaacaacccaaaaaaaaacccccccccccccccccaaaacccccccccccccffeeeeeeeeddddddddcccaaacccccc
abcccccccccaaaaccccacccccccaaaaaaccccccccccaaaaacccccccaaaacccaaacaccccaaaaaaaaaccccccccccccccccaaaaaaccccccccccccceeeeeeeeedacccccccccccccccccc
abaccccccccaaaaccccaaacaaacaaaaaaccccccccccaacaaccccccccaaaacaaaacaaacaaaaaaaaaacccccccccccccaacaaaaaacccccccccccccceeeeeeeaaacccccccccccccccaaa
abaaacccccccaaaccccaaaaaaaccaaaccccccccaaacccccccccccccccaaaaaaaacaaaaaaaaaaaaaaacacaaccaaacaaacccaacccccccccccccccccaacccaaaacccccccccccccccaaa
abaaaccccccccccccccaaaaaaccccccccccccccaaacccccccccccccccaaaaaaaccaaaaaaccaacccaccaaaaccaaaaaaaccccccccaaccccccccccccccccccaaacccccccccccccccaaa
abaaccccccccccccccaaaaaaacccccccccccaaaaaaaaccccccccccccccaaaaaaaaaaaaaacaaaccccccaaaaaccaaaaaaccccccaaaaccccccccccccccccccaaaccccccccccccaaaaaa
abaaaccccccccccccaaaaaaaaaacccccccccaaaaaaaacccccccccccaaaaaaaaaaaaaaaaaaacccccccaaaaaacaaaaaaaaaccccaaaaaacccccccccccccccccccccccccccccccaaaaaa";
        #endregion

    }
}
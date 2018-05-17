from simplex import Simplex

# Input Awal
maxmin = raw_input('maximize atau minimize? ')
nVar = input('berapa banyak variabel? ')
nCon = input('berapa banyak constraints? ')
inObj = raw_input('Masukkan Fungsi tujuan, contoh : 2x_1 + 1x_2. \n')
print 'Masukkan constraints, contoh : 1x_1 <= 9'
constraintsT0 = [raw_input() for _ in range(nCon)]
constraintsT1 = constraintsT0
print 'Masukkan toleransi, contoh : 20'
toleransi = [input() for _ in range(nCon)]
d = []
temp = []
temp2 = []

# Create ConstraintT1
for i in range(0,nCon):
	temp.append(int(constraintsT1[i].partition('= ')[-1]))

d = [temp[i]+toleransi[i] for i in range(len(temp))]
constraintsT1 = [constraintsT1[i].replace(constraintsT1[i].partition('= ')[-1], str(d[i])) for i in range(len(constraintsT1))]

for i in range(0,nCon):
	temp2.append(int(constraintsT1[i].partition('= ')[-1]))

temp3 = [temp2[i] - temp[i] for i in range(len(constraintsT1))]
# print temp3
# print constraintsT0
# print constraintsT1

# Proses t=0 dan t=1
objective = (maxmin, inObj)
Lp_systemT0 = Simplex(num_vars=nVar, constraints=constraintsT0, objective_function=objective)
Lp_systemT1 = Simplex(num_vars=nVar, constraints=constraintsT1, objective_function=objective)
zT0 = Lp_systemT0.optimize_val
zT1 = Lp_systemT1.optimize_val
xT0 = Lp_systemT0.solution
xT1 = Lp_systemT1.solution
print(xT0)
print 'zT0 = ' + str(zT0)
print(xT1)
print 'zT1 = ' + str(zT1)

# Membuat fuzzy
nVar = nVar + 1
constraintsFz = [constraintsT1[i].partition('<=')[0] for i in range(len(constraintsT1))]
print constraintsFz

constraintsFz = [constraintsFz[i] + "+ " + str(temp3[i]) + "x_" + str(nVar) + constraintsT1[i].partition("x_" + str(nVar-1))[-1] for i in range(len(constraintsT1))]
constraintsFz.append(inObj + " " + str(int(zT0-zT1)) + "x_" + str(nVar) + " >= " + str(int(zT0)))
objFz = (maxmin, "1x_" + str(nVar))
print constraintsFz
Lp_systemFz = Simplex(num_vars=nVar, constraints=constraintsFz, objective_function=objFz)
zFz = Lp_systemFz.optimize_val
xFz = Lp_systemFz.solution
print(xFz)
print 'Lambda = ' + str(float(zFz))





# if maxmin == "maximize":

# from simplex import Simplex
# objective = ('maximize', '1x_1 + 0x_2 + 0x_3')
# constraints = ['9x_1 - 2x_2 - 1x_3 <= -7', '6x_1 + 1x_2 + 0x_3 <= 9', '4x_1 + 1x_2 + 1x_3 <= 8', '20x_1 + 3x_2 + 10x_3 <= 50']
# Lp_system = Simplex(num_vars=3, constraints=constraints, objective_function=objective)
# print(Lp_system.solution)
# print(Lp_system.optimize_val)